namespace STM.Services.Services
{
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.Common.Utilities;
    using STM.DataTranferObjects.Jobs;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<IQueryable<JobDto>> Search(JobSearchDto dto)
        {
            var queryJob = await this._unitOfWork.GetRepositoryReadOnlyAsync<Job>().QueryAll();
            queryJob = queryJob.Include(x => x.JobUserRegisters);

            if (!string.IsNullOrEmpty(dto.Title))
            {
                var nameSearch = dto.Title.Trim().ToLower();
                queryJob = queryJob.Where(x => x.Title.ToLower().Contains(nameSearch));
            }

            if (!string.IsNullOrEmpty(dto.FileName))
            {
                queryJob = queryJob.Where(x => x.FilePath.ToLower().Contains(dto.FileName.ToLower().Trim()));
            }

            if (dto.MajorId.HasValue)
            {
                queryJob = queryJob.Where(x => x.MajorId == dto.MajorId);
            }

            if (dto.CountApply.HasValue)
            {
                queryJob = queryJob.Where(x => x.JobUserRegisters.Count <= dto.CountApply);
            }

            if (dto.Status.HasValue)
            {
                queryJob = queryJob.Where(x => x.Status == dto.Status);
            }

            var hostName = this.GetHostName();
            var query = queryJob.Include(x => x.JobUserRegisters).Include(x => x.Major)
                .OrderBy(x => x.CreatedAt)
                .Select(x => new JobDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    StartDate = x.StartDate,
                    CompanyName = x.CompanyName,
                    Address = x.Address,
                    WorkType = x.WorkType,
                    EndDate = x.EndDate,
                    MajorName = x.Major.Name,
                    MajorId = x.MajorId,
                    FilePathOriginal = x.FilePath,
                    FilePath = !string.IsNullOrEmpty(x.FilePath) ? $"{hostName}/{x.FilePath}" : string.Empty,
                    Skills = !string.IsNullOrEmpty(x.Skills) ? JsonConvert.DeserializeObject<List<string>>(x.Skills) : null,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                    IsApplyed = x.JobUserRegisters.Count(j => j.UserId == dto.CurrentUserId) > 0,
                    CountApplyed = x.JobUserRegisters.Count(),
                });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<IQueryable<UserApplyDto>> GetUserApplies(Guid jobId, UserApplySearchDto dto)
        {
            var queryJobUR = await this._unitOfWork.GetRepositoryReadOnlyAsync<JobUserRegister>().QueryAll();

            queryJobUR = queryJobUR.Where(x => x.JobId == jobId);

            if (!string.IsNullOrEmpty(dto.FullName))
            {
                var nameSearch = dto.FullName.Trim().ToLower();
                queryJobUR = queryJobUR.Where(x => x.FullName.ToLower().Contains(nameSearch));
            }

            if (dto.Status.HasValue)
            {
                queryJobUR = queryJobUR.Where(x => x.Status == dto.Status);
            }

            var hostName = this.GetHostName();
            var query = queryJobUR
                .OrderBy(x => x.CreatedAt)
                .Select(x => new UserApplyDto
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Content = x.Content,
                    FilePath = !string.IsNullOrEmpty(x.FilePath) ? $"{hostName}/{x.FilePath}" : string.Empty,
                    FilePathOriginal = x.FilePath,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<JobDto?> FindById(Guid id, Guid currentUserId)
        {
            var queryJob = await this._unitOfWork.GetRepositoryReadOnlyAsync<Job>().QueryAll();
            var job = queryJob.Include(x => x.JobUserRegisters).Include(x => x.Major).FirstOrDefault(i => i.Id == id);

            if (job == null)
            {
                return null;
            }

            var result = this._mapper.Map<JobDto>(job);
            var hostName = this.GetHostName();
            result.FilePathOriginal = job.FilePath;
            result.FilePath = !string.IsNullOrEmpty(result.FilePath) ? $"{hostName}/{result.FilePath}" : string.Empty;
            result.IsApplyed = job.JobUserRegisters.Count(x => x.UserId == currentUserId) > 0;

            return result;
        }

        public async Task<string> Create(JobSaveDto dto)
        {
            var jobRep = this._unitOfWork.GetRepositoryAsync<Job>();

            var newJob = new Job
            {
                Title = dto.Title,
                Content = dto.Content,
                MajorId = dto.MajorId,
                CompanyName = dto.CompanyName,
                WorkType = dto.WorkType,
                Skills = JsonConvert.SerializeObject(dto.Skills),
                Address = dto.Address,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            DateTime startDate;
            if (!string.IsNullOrEmpty(dto.StartDateFormat) && DateTime.TryParse(dto.StartDateFormat, out startDate))
            {
                newJob.StartDate = startDate;
            }

            DateTime endDate;
            if (!string.IsNullOrEmpty(dto.EndDateFormat) && DateTime.TryParse(dto.EndDateFormat, out endDate))
            {
                newJob.EndDate = endDate;
            }

            if (dto.IsDeleteFile)
            {
                newJob.FilePath = null;
            }
            else if (!string.IsNullOrEmpty(dto.FileBase64))
            {
                var folderPath = $"{GlobalConstants.ResourceFolder}/{GlobalConstants.UploadJobJD}";
                Utils.CreateFolder(folderPath);
                var filePath = $"{folderPath}/{dto.FileName}";
                newJob.FilePath = filePath;

                Utils.ConvertBase64ToFile(dto.FileBase64, filePath);
            }

            await jobRep.Add(newJob);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.Job);
        }

        public async Task<string> Update(JobSaveDto dto)
        {
            var jobRep = this._unitOfWork.GetRepositoryAsync<Job>();

            var job = await jobRep.Single(i => i.Id == dto.Id);

            if (job == null)
            {
                return Messages.NotFound;
            }

            job.Title = dto.Title;
            job.MajorId = dto.MajorId;
            job.Content = dto.Content;
            job.CompanyName = dto.CompanyName;
            job.WorkType = dto.WorkType;
            job.Skills = JsonConvert.SerializeObject(dto.Skills);
            job.Address = dto.Address;
            job.Status = dto.Status;

            DateTime startDate;
            if (!string.IsNullOrEmpty(dto.StartDateFormat) && DateTime.TryParse(dto.StartDateFormat, out startDate))
            {
                job.StartDate = startDate;
            }

            DateTime endDate;
            if (!string.IsNullOrEmpty(dto.EndDateFormat) && DateTime.TryParse(dto.EndDateFormat, out endDate))
            {
                job.EndDate = endDate;
            }

            if (dto.IsDeleteFile)
            {
                job.FilePath = null;
            }
            else if (!string.IsNullOrEmpty(dto.FileBase64))
            {
                var folderPath = $"{GlobalConstants.ResourceFolder}/{GlobalConstants.UploadJobJD}";
                Utils.CreateFolder(folderPath);
                var filePath = $"{folderPath}/{dto.FileName}";
                job.FilePath = filePath;

                Utils.ConvertBase64ToFile(dto.FileBase64, filePath);
            }

            await jobRep.Update(job);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.Job);
        }

        public async Task<string> Delete(Guid id)
        {
            var jobRep = this._unitOfWork.GetRepositoryAsync<Job>();
            var job = await jobRep.Single(i => i.Id == id);

            if (job == null)
            {
                return Messages.NotFound;
            }

            await jobRep.Delete(job);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Job);
        }

        public async Task<string> ApplyJob(Guid id, ApplyJobSaveDto dto)
        {
            var jobUserRegisterRep = this._unitOfWork.GetRepositoryAsync<JobUserRegister>();

            var newJobUserRegister = new JobUserRegister()
            {
                UserId = dto.UserId,
                JobId = dto.JobId,
                FullName = dto.FullName,
                Content = dto.Content,
            };

            if (!string.IsNullOrEmpty(dto.FileBase64))
            {
                var folderPath = $"{GlobalConstants.ResourceFolder}/{GlobalConstants.UploadCV}";
                Utils.CreateFolder(folderPath);
                var filePath = $"{folderPath}/{dto.FileName}";
                newJobUserRegister.FilePath = filePath;

                Utils.ConvertBase64ToFile(dto.FileBase64, filePath);
            }

            await jobUserRegisterRep.Add(newJobUserRegister);
            await this._unitOfWork.SaveChangesAsync();

            return Messages.ApplyJob;
        }

        private string? GetHostName()
        {
            var context = this._httpContextAccessor.HttpContext;
            var hostName = context?.Request.Host.Value;
            return hostName ?? null;
        }
    }
}
