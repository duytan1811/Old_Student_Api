namespace STM.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
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
            queryNews = queryNews.Include(x => x.UserLikeNews);
            if (!string.IsNullOrEmpty(dto.Content))
            {
                var contentSearch = dto.Content.Trim().ToLower();
                queryNews = queryNews.Where(x => x.Content.ToLower().Contains(contentSearch));
            }

            if (dto.CountLike.HasValue)
            {
                queryNews = queryNews.Where(x => x.UserLikeNews.Count <= dto.CountLike);
            }

            if (dto.CountComment.HasValue)
            {
                queryNews = queryNews.Where(x => x.NewComments.Count <= dto.CountComment);
            }

            if (dto.Type.HasValue)
            {
                queryNews = queryNews.Where(x => x.Type == dto.Type);
            }

            if (dto.Status.HasValue)
            {
                queryNews = queryNews.Where(x => x.Status == dto.Status);
            }

            var query = queryNews.Select(x => new NewsDto
            {
                Id = x.Id,
                Content = x.Content,
                Type = x.Type.ToString(),
                CountLike = x.UserLikeNews.Count,
                CountComment = x.NewComments.Count,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                CreatedById = x.CreatedById,
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                ColumnNames.CountComment => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CountComment).ThenByDescending(x => x.CountLike),
                _ => query,
            };
        }

        public async Task<NewsDto?> FindById(Guid id, Guid currenUserId)
        {
            var queryNews = await this._unitOfWork.GetRepositoryReadOnlyAsync<News>().QueryAll();
            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();
            var queryLike = await this._unitOfWork.GetRepositoryReadOnlyAsync<UserLikeNews>().QueryAll();
            var news = queryNews.Include(x => x.UserLikeNews).Include(x => x.NewComments).FirstOrDefault(i => i.Id == id);

            if (news == null)
            {
                return null;
            }

            var result = new NewsDto
            {
                Id = news.Id,
                Status = news.Status,
                Content = news.Content,
                Type = news.Type.AsInt().ToString(),
                StartDate = news.StartDate,
                EndDate = news.EndDate,
                CountLike = news.UserLikeNews.Count,
                CountComment = news.NewComments.Count,
                IsLiked = queryLike.Where(x => x.UserId == currenUserId && x.NewsId == news.Id).Count() > 0,
            };

            if (news.CreatedById.HasValue)
            {
                var user = queryUser.Include(x => x.Student).FirstOrDefault(x => x.Id == news.CreatedById);
                result.CreatedByName = user.IsAdmin ? "Admin" : user.Student.FullName;
                result.CreatedByAvatar = user?.Student?.Avatar;
            }

            return result;
        }

        public async Task<IQueryable<CommentDto>?> GetComments(CommentSearchDto dto)
        {
            var queryComments = await this._unitOfWork.GetRepositoryReadOnlyAsync<NewsComment>().QueryAll();

            queryComments = queryComments.Include(x => x.User).Where(i => i.NewId == dto.NewsId);

            var query = queryComments.Select(x => new CommentDto
            {
                Id = x.Id,
                UserId = x.UserId,
                Status = x.Status,
                Content = x.Content,
                CreatedAt = x.CreatedAt,
                UserAvatar = x.User.IsAdmin ? string.Empty : x.User.Student.Avatar,
                CreatedByName = x.User.IsAdmin ? "Admin" : x.User.Student.FullName,
            }).OrderByDescending(x => x.CreatedAt);

            return query;
        }

        public async Task<string> Create(NewsSaveDto dto)
        {
            var newsRep = this._unitOfWork.GetRepositoryAsync<News>();
            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();

            var newNews = new News
            {
                Type = dto.Type,
                Content = dto.Content,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };
            var user = queryUser.FirstOrDefault(x => x.Id == dto.CurrentUserId);

            if (!user.IsAdmin && !user.IsTeacher)
            {
                newNews.Status = StatusEnum.WaitingApproval;
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

            news.Content = dto.Content;
            news.Type = dto.Type;
            news.Status = dto.Status;

            await newsRep.Update(news);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.News);
        }

        public async Task<string> Like(Guid newsId, Guid userId)
        {
            var newsRep = this._unitOfWork.GetRepositoryAsync<News>();
            var userLikeNewsRep = this._unitOfWork.GetRepositoryAsync<UserLikeNews>();

            var news = await newsRep.FindById(newsId);

            if (news == null)
            {
                return string.Format(Messages.NotFound, GlobalConstants.Menu.News);
            }

            var userLikeNews = await userLikeNewsRep.Single(x => x.NewsId == newsId && x.UserId == userId);
            if (userLikeNews == null)
            {
                await userLikeNewsRep.Add(new UserLikeNews
                {
                    UserId = userId,
                    NewsId = newsId,
                });
            }
            else
            {
                await userLikeNewsRep.Delete(userLikeNews);
            }

            await this._unitOfWork.SaveChangesAsync();
            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.News);
        }

        public async Task<string> Comment(CommentSaveDto dto)
        {
            var newsRep = this._unitOfWork.GetRepositoryAsync<News>();
            var newCommentRep = this._unitOfWork.GetRepositoryAsync<NewsComment>();

            var news = await newsRep.FindById(dto.NewsId);

            if (news == null)
            {
                return string.Format(Messages.NotFound, GlobalConstants.Menu.News);
            }

            var newComment = new NewsComment
            {
                UserId = dto.UserId,
                NewId = dto.NewsId,
                Content = dto.Content,
            };

            await newCommentRep.Add(newComment);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.News);
        }

        public async Task<string> Confirm(Guid newId)
        {
            var newsRep = this._unitOfWork.GetRepositoryAsync<News>();

            var news = await newsRep.FindById(newId);

            if (news == null)
            {
                return string.Format(Messages.NotFound, GlobalConstants.Menu.News);
            }

            news.Status = StatusEnum.Active;

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

        public async Task<MemoryStream> ExportExcel(NewsSearchDto dto)
        {
            string templatePath = Path.Combine(Environment.CurrentDirectory, GlobalConstants.ResourceFolder, GlobalConstants.TemplateFolder);
            string reportPath = Path.Combine(Environment.CurrentDirectory, GlobalConstants.ResourceFolder, GlobalConstants.ReportFolder);
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }

            string fileName = string.Format(FileNameConstants.StatisticsNews, DateTime.Now.ToString("yyyyMMddhhmmsss"));
            FileInfo newFile = new FileInfo(Path.Combine(reportPath, fileName));
            FileInfo templateFile = new FileInfo(Path.Combine(templatePath, FileNameConstants.StatisticsNewsTemplate));

            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();
            queryUser = queryUser.Include(x => x.Student);
            var data = (await this.Search(dto)).ToList().OrderByDescending(x => x.CountComment).ThenByDescending(x => x.CountLike);

            var createdByIdsList = data.Select(x => x.CreatedById).ToList();
            var createdByList = queryUser.Where(x => createdByIdsList.Contains(x.Id)).ToList();

            using (ExcelPackage pck = new ExcelPackage(newFile, templateFile))
            {
                var row = 4;
                ExcelWorksheet sheet = pck.Workbook.Worksheets[0];
                foreach (var item in data)
                {
                    var createdyBy = createdByList.Find(x => x.Id == item.CreatedById);
                    sheet.Cells[$"B{row}"].Value = row - 3;
                    sheet.Cells[$"C{row}"].Value = EnumHelper<NewsTypeEnum>.GetDisplayValue(item.Type);
                    sheet.Cells[$"D{row}"].Value = item.CountLike ?? 0;
                    sheet.Cells[$"E{row}"].Value = item.CountComment ?? 0;
                    sheet.Cells[$"F{row}"].Value = item.Status.HasValue ? EnumHelper<StatusEnum>.GetDisplayValue(item.Status.Value) : string.Empty;
                    sheet.Cells[$"G{row}"].Value = createdyBy.IsAdmin ? "Admin" : createdyBy.Student.FullName;
                    row++;
                }

                ExcelHelper.RenderBorderAll(sheet, 4, 2, row - 1, 7, ExcelBorderStyle.Thin);

                sheet.Name = "BC";
                var stream = new MemoryStream();
                pck.ToStream(newFile);
                pck.SaveAs(stream);
                return stream;
            }
        }
    }
}
