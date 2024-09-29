namespace STM.Services.Services
{
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.Common.Utilities;
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

            if (dto.Type.HasValue)
            {
                queryNews = queryNews.Where(x => x.Type == dto.Type);
            }

            if (dto.Status.HasValue)
            {
                queryNews = queryNews.Where(x => x.Status == dto.Status);
            }

            var query = queryNews.OrderBy(x => x.CreatedAt).Select(x => new NewsDto
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type.ToString(),
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
                Description = news.Description,
                Content = news.Content,
                Type = news.Type.AsInt().ToString(),
                StartDate = news.StartDate,
                EndDate = news.EndDate,
            };
        }

        public async Task<string> Create(NewsSaveDto dto)
        {
            var newsRep = this._unitOfWork.GetRepositoryAsync<News>();

            var newNews = new News
            {
                Name = dto.Name,
                Type = dto.Type,
                Description = dto.Description,
                Content = dto.Content,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            if (dto.Type == NewsTypeEnum.ReunionEvent)
            {
                DateTime startDate;
                if (!string.IsNullOrEmpty(dto.StartDateFormat) && DateTime.TryParse(dto.StartDateFormat, out startDate))
                {
                    newNews.StartDate = startDate;
                }

                DateTime endDate;
                if (!string.IsNullOrEmpty(dto.EndDateFormat) && DateTime.TryParse(dto.EndDateFormat, out endDate))
                {
                    newNews.EndDate = endDate;
                }
            }

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
            news.Description = dto.Description;
            news.Content = dto.Content;
            news.Type = dto.Type;
            news.Status = dto.Status;

            if (dto.Type == NewsTypeEnum.ReunionEvent)
            {
                DateTime startDate;
                if (!string.IsNullOrEmpty(dto.StartDateFormat) && DateTime.TryParse(dto.StartDateFormat, out startDate))
                {
                    news.StartDate = startDate;
                }

                DateTime endDate;
                if (!string.IsNullOrEmpty(dto.EndDateFormat) && DateTime.TryParse(dto.EndDateFormat, out endDate))
                {
                    news.EndDate = endDate;
                }
            }
            else
            {
                news.StartDate = null;
                news.EndDate = null;
            }

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
