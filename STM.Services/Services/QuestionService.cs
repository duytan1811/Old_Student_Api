namespace STM.Services.Services
{
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.Questions;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<QuestionDto>> Search(QuestionSearchDto dto)
        {
            var queryQuestion = await this._unitOfWork.GetRepositoryReadOnlyAsync<Question>().QueryAll();

            if (!string.IsNullOrEmpty(dto.Name))
            {
                var nameSearch = dto.Name.Trim().ToLower();
                queryQuestion = queryQuestion.Where(x => x.Name.ToLower().Contains(nameSearch));
            }

            if (dto.Status.HasValue)
            {
                queryQuestion = queryQuestion.Where(x => x.Status == dto.Status);
            }

            var query = queryQuestion.OrderBy(x => x.CreatedAt).Select(x => new QuestionDto
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

        public async Task<QuestionDto?> FindById(Guid id)
        {
            var queryQuestion = await this._unitOfWork.GetRepositoryReadOnlyAsync<Question>().QueryAll();
            var question = queryQuestion.FirstOrDefault(i => i.Id == id);

            if (question == null)
            {
                return null;
            }

            return new QuestionDto
            {
                Id = question.Id,
                Name = question.Name,
                Status = question.Status,
                CreatedAt = question.CreatedAt,
                CreatedById = question.CreatedById,
                UpdatedAt = question.UpdatedAt,
                UpdatedById = question.UpdatedById,
            };
        }

        public async Task<string> Create(QuestionSaveDto dto)
        {
            var questionRep = this._unitOfWork.GetRepositoryAsync<Question>();

            var newQuestion = new Question
            {
                Name = dto.Name,
                IsComment = dto.IsComment,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            await questionRep.Add(newQuestion);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.Question);
        }

        public async Task<string> Update(QuestionSaveDto dto)
        {
            var questionRep = this._unitOfWork.GetRepositoryAsync<Question>();

            var question = await questionRep.Single(i => i.Id == dto.Id);

            if (question == null)
            {
                return Messages.NotFound;
            }

            question.Name = dto.Name;
            question.IsComment = dto.IsComment;
            question.Status = dto.Status;

            await questionRep.Update(question);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.Question);
        }

        public async Task<string> Delete(Guid id)
        {
            var questionRep = this._unitOfWork.GetRepositoryAsync<Question>();
            var querySurvey = await this._unitOfWork.GetRepositoryReadOnlyAsync<SurveyTemplate>().QueryAll();

            var question = await questionRep.Single(i => i.Id == id);

            if (question == null)
            {
                return Messages.NotFound;
            }

            var isExistsSurvey = querySurvey.Where(x => x.QuestionIds.Contains(id.ToString())).Any();
            if (isExistsSurvey)
            {
                return string.Format(Messages.CannotDelete, GlobalConstants.Menu.Question);
            }

            await questionRep.Delete(question);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Question);
        }
    }
}
