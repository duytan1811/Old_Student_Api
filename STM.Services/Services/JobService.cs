namespace STM.Services.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
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

        public JobService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IQueryable<JobDto>> Search(JobSearchDto dto)
        {
            var queryJob = await this._unitOfWork.GetRepositoryReadOnlyAsync<Job>().QueryAll();

            if (!string.IsNullOrEmpty(dto.Title))
            {
                var nameSearch = dto.Title.Trim().ToLower();
                queryJob = queryJob.Where(x => x.Title.ToLower().Contains(nameSearch));
            }

            if (dto.Status.HasValue)
            {
                queryJob = queryJob.Where(x => x.Status == dto.Status);
            }

            var query = queryJob.Include(x => x.Major).OrderBy(x => x.CreatedAt).Select(x => new JobDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                MajorName = x.Major.Name,
                MajorId = x.MajorId,
                FilePath = x.FilePath,

                Status = x.Status,
                CreatedAt = x.CreatedAt,
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<JobDto?> FindById(Guid id)
        {
            var queryJob = await this._unitOfWork.GetRepositoryReadOnlyAsync<Job>().QueryAll();
            var job = queryJob.FirstOrDefault(i => i.Id == id);

            if (job == null)
            {
                return null;
            }

            return this._mapper.Map<JobDto>(job);
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
                Skills = dto.Skills,
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
            job.Skills = dto.Skills;
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
    }
}
