﻿namespace STM.Services.Services
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
            query = query.Where(x => !x.IsAdmin).Where(x => x.Status == StatusEnum.Active.AsInt());
            return query.Select(x => new SelectListItem
            {
                Value = x.Id.ToString().ToLower(),
                Text = $"{x.UserName} - {x.Name}",
            }).ToList();
        }
    }
}
