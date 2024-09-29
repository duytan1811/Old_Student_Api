namespace STM.Services.Services
{
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.News;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<NewsDto>> Search(NewsSearchDto dto)
        {
            var queryNews = await this._unitOfWork.GetRepositoryReadOnlyAsync<News>().QueryAll();

            if (!string.IsNullOrEmpty(dto.Name))
            {
                var nameSearch = dto.Name.Trim().ToLower();
                queryNews = queryNews.Where(x => x.Name.ToLower().Contains(nameSearch));
            }

            if (dto.Status.HasValue)
            {
                queryNews = queryNews.Where(x => x.Status == dto.Status);
            }

            var query = queryNews.OrderBy(x => x.CreatedAt).Select(x => new NewsDto
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

        public async Task<NewsDto?> FindById(Guid id)
        {
            var queryNews = await this._unitOfWork.GetRepositoryReadOnlyAsync<News>().QueryAll();
            var news = queryNews.FirstOrDefault(i => i.Id == id);

            if (news == null)
            {
                return null;
            }

            return new NewsDto
            {
                Id = news.Id,
                Name = news.Name,
                Status = news.Status,
                CreatedAt = news.CreatedAt,
                CreatedById = news.CreatedById,
                UpdatedAt = news.UpdatedAt,
                UpdatedById = news.UpdatedById,
            };
        }

        public async Task<string> Create(NewsSaveDto dto)
        {
            var newsRep = this._unitOfWork.GetRepositoryAsync<News>();

            var newNews = new News
            {
                Name = dto.Name,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            await newsRep.Add(newNews);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.News);
        }

        public async Task<string> Update(NewsSaveDto dto)
        {
            var newsRep = this._unitOfWork.GetRepositoryAsync<News>();

            var news = await newsRep.Single(i => i.Id == dto.Id);

            if (news == null)
            {
                return Messages.NotFound;
            }

            news.Name = dto.Name;
            news.Status = dto.Status;

            await newsRep.Update(news);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.News);
        }

        public async Task<string> Delete(Guid id)
        {
            var newsRep = this._unitOfWork.GetRepositoryAsync<News>();
            var news = await newsRep.Single(i => i.Id == id);

            if (news == null)
            {
                return Messages.NotFound;
            }

            await newsRep.Delete(news);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.News);
        }
    }
}
