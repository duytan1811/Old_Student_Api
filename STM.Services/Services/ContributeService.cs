namespace STM.Services.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.Contributes;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class ContributeService : IContributeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContributeService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IQueryable<ContributeDto>> Search(ContributeSearchDto dto)
        {
            var queryContribute = await this._unitOfWork.GetRepositoryReadOnlyAsync<Contribute>().QueryAll();

            queryContribute = queryContribute.Include(x => x.Student);

            if (!string.IsNullOrEmpty(dto.FullName))
            {
                var nameSearch = dto.FullName.Trim().ToLower();
                queryContribute = queryContribute.Where(x => x.Student.FullName.ToLower().Contains(nameSearch));
            }

            if (dto.Type.HasValue)
            {
                queryContribute = queryContribute.Where(x => x.Type == dto.Type);
            }

            if (dto.Amount.HasValue)
            {
                queryContribute = queryContribute.Where(x => x.Amount == dto.Amount);
            }

            if (dto.Status.HasValue)
            {
                queryContribute = queryContribute.Where(x => x.Status == dto.Status);
            }

            var query = queryContribute.OrderBy(x => x.CreatedAt).Select(x => new ContributeDto
            {
                Id = x.Id,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<ContributeDto?> FindById(Guid id)
        {
            var queryContribute = await this._unitOfWork.GetRepositoryReadOnlyAsync<Contribute>().QueryAll();
            var contribute = queryContribute.FirstOrDefault(i => i.Id == id);

            if (contribute == null)
            {
                return null;
            }

            return this._mapper.Map<ContributeDto>(contribute);
        }

        public async Task<string> Create(ContributeSaveDto dto)
        {
            var contributeRep = this._unitOfWork.GetRepositoryAsync<Contribute>();

            var newContribute = new Contribute
            {
                Type = dto.Type,
                StudentId = dto.StudentId,
                Amount = dto.Amount,
                Detail = dto.Detail,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            await contributeRep.Add(newContribute);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.Contribute);
        }

        public async Task<string> Update(ContributeSaveDto dto)
        {
            var contributeRep = this._unitOfWork.GetRepositoryAsync<Contribute>();

            var contribute = await contributeRep.Single(i => i.Id == dto.Id);

            if (contribute == null)
            {
                return Messages.NotFound;
            }

            contribute = this._mapper.Map<ContributeSaveDto, Contribute>(dto);

            await contributeRep.Update(contribute);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.Contribute);
        }

        public async Task<string> Delete(Guid id)
        {
            var contributeRep = this._unitOfWork.GetRepositoryAsync<Contribute>();
            var contribute = await contributeRep.Single(i => i.Id == id);

            if (contribute == null)
            {
                return Messages.NotFound;
            }

            await contributeRep.Delete(contribute);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Contribute);
        }
    }
}
