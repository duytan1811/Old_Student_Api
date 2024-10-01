namespace STM.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Fourms;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class FourmService : IFourmService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FourmService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<FourmDto>> Search(FourmSearchDto dto, Guid userId)
        {
            var queryNews = await this._unitOfWork.GetRepositoryReadOnlyAsync<News>().QueryAll();
            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();
            var queryStudent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Student>().QueryAll();

            queryNews = queryNews.Include(x => x.NewComments);

            if (dto.Type.HasValue)
            {
                queryNews = queryNews.Where(x => x.Type == dto.Type);
            }

            if (dto.Status.HasValue)
            {
                queryNews = queryNews.Where(x => x.Status == dto.Status);
            }

            var query = (from n in queryNews
                         join u in queryUser on n.CreatedById equals u.Id
                         join s in queryStudent on u.Id equals s.UserId into us
                         from res in us.DefaultIfEmpty()
                         select new FourmDto
                         {
                             Id = n.Id,
                             Content = n.Content,
                             Type = n.Type,
                             Status = n.Status,
                             CreatedAt = n.CreatedAt,
                             CountLike = n.UserLikeNews.Count,
                             CountComment = n.NewComments.Count,
                             IsLiked = n.UserLikeNews.Where(x => x.UserId == userId).Count() > 0,
                             CreatedByName = u.IsAdmin ? "Admin" : res.FullName,
                             CreatedByAvatar = res.Avatar,
                         }).OrderByDescending(x => x.CreatedAt);

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }
    }
}
