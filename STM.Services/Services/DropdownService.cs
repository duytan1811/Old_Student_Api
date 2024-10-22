namespace STM.Services.Services
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using STM.Common.Enums;
    using STM.Common.Utilities;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class DropdownService : IDropdownService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DropdownService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<SelectListItem>> GetUsers()
        {
            var query = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();
            query = query.Where(x => !x.IsAdmin).Where(x => x.Status == StatusEnum.Active);
            return query.Select(x => new SelectListItem
            {
                Value = x.Id.ToString().ToLower(),
                Text = $"{x.UserName}",
            }).ToList();
        }

        public async Task<List<SelectListItem>> GetMajors()
        {
            var query = await this._unitOfWork.GetRepositoryReadOnlyAsync<Major>().QueryAll();
            query = query.Where(x => x.Status == StatusEnum.Active);
            return query.Select(x => new SelectListItem
            {
                Value = x.Id.ToString().ToLower(),
                Text = x.Name,
            }).ToList();
        }

        public async Task<List<SelectListItem>> GetRoles()
        {
            var query = await this._unitOfWork.GetRepositoryReadOnlyAsync<Role>().QueryAll();
            query = query.Where(x => x.Status == StatusEnum.Active);
            return query.Select(x => new SelectListItem
            {
                Value = x.Id.ToString().ToLower(),
                Text = x.Name,
            }).ToList();
        }

        public List<SelectListItem> GetNewTypes()
        {
            return EnumHelper<NewsTypeEnum>.ConvertToSelectList(false);
        }

        public List<SelectListItem> GetEventTypes()
        {
            return EnumHelper<EventTypeEnum>.ConvertToSelectList(false);
        }

        public async Task<List<SelectListItem>> GetQuestions()
        {
            var query = await this._unitOfWork.GetRepositoryReadOnlyAsync<Question>().QueryAll();
            query = query.Where(x => x.Status == StatusEnum.Active);
            return query.Select(x => new SelectListItem
            {
                Value = x.Id.ToString().ToLower(),
                Text = x.Name,
            }).ToList();
        }

        public List<SelectListItem> GetSurveyTypes()
        {
            return EnumHelper<SurveyTypeEnum>.ConvertToSelectList(false);
        }
    }
}
