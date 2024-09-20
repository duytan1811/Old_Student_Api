namespace STM.Services.Services
{
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.Majors;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class MajorService : IMajorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MajorService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<MajorDto>> Search(MajorSearchDto dto)
        {
            var queryMajor = await this._unitOfWork.GetRepositoryReadOnlyAsync<Major>().QueryAll();

            if (!string.IsNullOrEmpty(dto.Name))
            {
                var nameSearch = dto.Name.Trim().ToLower();
                queryMajor = queryMajor.Where(x => x.Name.ToLower().Contains(nameSearch));
            }

            if (dto.Status.HasValue)
            {
                queryMajor = queryMajor.Where(x => x.Status == dto.Status);
            }

            var query = queryMajor.OrderBy(x => x.CreatedAt).Select(x => new MajorDto
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<MajorDto?> FindById(Guid id)
        {
            var queryMajor = await this._unitOfWork.GetRepositoryReadOnlyAsync<Major>().QueryAll();
            var major = queryMajor.FirstOrDefault(i => i.Id == id);

            if (major == null)
            {
                return null;
            }

            return new MajorDto
            {
                Id = major.Id,
                Name = major.Name,
                Status = major.Status,
                CreatedAt = major.CreatedAt,
                CreatedById = major.CreatedById,
                UpdatedAt = major.UpdatedAt,
                UpdatedById = major.UpdatedById,
            };
        }

        public async Task<string> Create(MajorSaveDto dto)
        {
            var majorRep = this._unitOfWork.GetRepositoryAsync<Major>();

            var newMajor = new Major
            {
                Name = dto.Name,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            await majorRep.Add(newMajor);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.Major);
        }

        public async Task<string> Update(MajorSaveDto dto)
        {
            var majorRep = this._unitOfWork.GetRepositoryAsync<Major>();

            var major = await majorRep.Single(i => i.Id == dto.Id);

            if (major == null)
            {
                return Messages.NotFound;
            }

            major.Name = dto.Name;
            major.Status = dto.Status;

            await majorRep.Update(major);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.Major);
        }

        public async Task<string> Delete(Guid id)
        {
            var majorRep = this._unitOfWork.GetRepositoryAsync<Major>();
            var major = await majorRep.Single(i => i.Id == id);

            if (major == null)
            {
                return Messages.NotFound;
            }

            await majorRep.Delete(major);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Major);
        }
    }
}
