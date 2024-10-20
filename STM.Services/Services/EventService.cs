namespace STM.Services.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.Common.Utilities;
    using STM.DataTranferObjects.Email;
    using STM.DataTranferObjects.Events;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;
    using STM.Services.ScheduleJob;

    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ISchedulingService _schedulingService;

        public EventService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceScopeFactory scopeFactory,
            ISchedulingService schedulingService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._scopeFactory = scopeFactory;
            this._schedulingService = schedulingService;
        }

        public async Task<IQueryable<EventDto>> Search(EventSearchDto dto)
        {
            var queryEvent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Event>().QueryAll();

            queryEvent = queryEvent.Include(x => x.EventRegisters);

            if (dto.Type.HasValue)
            {
                queryEvent = queryEvent.Where(x => x.Type == dto.Type);
            }

            if (dto.StartDate.HasValue)
            {
                queryEvent = queryEvent.Where(x => x.StartDate >= dto.StartDate);
            }

            if (dto.EndDate.HasValue)
            {
                queryEvent = queryEvent.Where(x => x.EndDate <= dto.EndDate);
            }

            if (dto.Status.HasValue)
            {
                queryEvent = queryEvent.Where(x => x.Status == dto.Status);
            }

            var query = queryEvent
                .OrderBy(x => x.CreatedAt)
                .Select(x => new EventDto
                {
                    Id = x.Id,
                    Content = x.Content,
                    Title = x.Title,
                    Type = x.Type,
                    StartDate = x.StartDate,
                    Address = x.Address,
                    EndDate = x.EndDate,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                    CountEventRegister = x.EventRegisters.Count,
                    IsRegister = x.EventRegisters.Any(x => x.UserId == dto.UserId),
                });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                ColumnNames.CountEventRegister => dto.Ascending ? query.OrderBy(x => x.CountEventRegister) : query.OrderByDescending(x => x.CountEventRegister),
                _ => query,
            };
        }

        public async Task<IQueryable<EventRegisterDto>> GetUserRegisters(Guid eventId, EventRegisterSearchDto dto)
        {
            var queryEventR = await this._unitOfWork.GetRepositoryReadOnlyAsync<EventRegister>().QueryAll();

            queryEventR = queryEventR.Include(x => x.User).ThenInclude(x => x.Student).Where(x => x.EventId == eventId);

            if (dto.UserId.HasValue)
            {
                queryEventR = queryEventR.Where(x => x.UserId == dto.UserId);
            }

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
            {
                var phoneN = dto.PhoneNumber.Trim().ToLower();
                queryEventR = queryEventR.Where(x => x.PhoneNumber.ToLower().Contains(phoneN));
            }

            if (!string.IsNullOrEmpty(dto.Email))
            {
                var emailN = dto.Email.Trim().ToLower();
                queryEventR = queryEventR.Where(x => x.Email.ToLower().Contains(emailN));
            }

            if (dto.Status.HasValue)
            {
                queryEventR = queryEventR.Where(x => x.Status == dto.Status);
            }

            var query = queryEventR
                .OrderBy(x => x.CreatedAt)
                .Select(x => new EventRegisterDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FullName = x.User.Student.FullName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<EventDto?> FindById(Guid id, Guid currentUserId)
        {
            var queryEvent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Event>().QueryAll();
            var objEvent = queryEvent.FirstOrDefault(i => i.Id == id);

            if (objEvent == null)
            {
                return null;
            }

            var result = this._mapper.Map<EventDto>(objEvent);

            return result;
        }

        public async Task<string> Create(EventSaveDto dto)
        {
            var eventRep = this._unitOfWork.GetRepositoryAsync<Event>();
            var queryStudent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Student>().QueryAll();

            var newEvent = new Event
            {
                Content = dto.Content,
                Title = dto.Title,
                Address = dto.Address,
                Type = dto.Type,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            DateTime startDate;
            if (!string.IsNullOrEmpty(dto.StartDateFormat) && DateTime.TryParse(dto.StartDateFormat, out startDate))
            {
                newEvent.StartDate = startDate;
            }

            DateTime endDate;
            if (!string.IsNullOrEmpty(dto.EndDateFormat) && DateTime.TryParse(dto.EndDateFormat, out endDate))
            {
                newEvent.EndDate = endDate;
            }

            await eventRep.Add(newEvent);
            await this._unitOfWork.SaveChangesAsync();

            EventNotificationJob.SetScopeFactory(this._scopeFactory);

            var emailAddress = queryStudent.Where(x => !string.IsNullOrEmpty(x.Email)).Select(x => x.Email).Distinct().ToList();
            var emailInfo = new EmailInfoDto
            {
                Title = "[STM] Sự kiện mới",
                EmailAddress = emailAddress,
            };
            this._schedulingService.ScheduleJob<EventNotificationJob>(Guid.NewGuid().ToString(), DateTime.Now, new Dictionary<string, string>
                            {
                                { "EmailInfoAsJson", JsonConvert.SerializeObject(emailInfo) },
                                { "StartDate", newEvent.StartDate?.ToString("HH:mm dd/MM/yyyy") },
                                { "EndDate", newEvent.EndDate?.ToString("HH:mm dd/MM/yyyy") },
                                { "EventAddress", newEvent.Address },
                                { "EventContent", newEvent.Content },
                            });

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.Event);
        }

        public async Task<string> Update(EventSaveDto dto)
        {
            var eventRep = this._unitOfWork.GetRepositoryAsync<Event>();

            var objEvent = await eventRep.Single(i => i.Id == dto.Id);

            if (objEvent == null)
            {
                return Messages.NotFound;
            }

            objEvent.Title = dto.Title;
            objEvent.Content = dto.Content;
            objEvent.Address = dto.Address;
            objEvent.Type = dto.Type;

            DateTime startDate;
            if (!string.IsNullOrEmpty(dto.StartDateFormat) && DateTime.TryParse(dto.StartDateFormat, out startDate))
            {
                objEvent.StartDate = startDate;
            }

            DateTime endDate;
            if (!string.IsNullOrEmpty(dto.EndDateFormat) && DateTime.TryParse(dto.EndDateFormat, out endDate))
            {
                objEvent.EndDate = endDate;
            }

            await eventRep.Update(objEvent);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.Event);
        }

        public async Task<string> Delete(Guid id)
        {
            var eventRep = this._unitOfWork.GetRepositoryAsync<Event>();
            var eventRegisRep = this._unitOfWork.GetRepositoryAsync<EventRegister>();

            var objEvent = await eventRep.Single(i => i.Id == id);

            if (objEvent == null)
            {
                return Messages.NotFound;
            }

            var evetRigs = await eventRegisRep.QueryCondition(x => x.EventId == objEvent.Id);

            await eventRegisRep.Delete(evetRigs.ToList());
            await eventRep.Delete(objEvent);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Event);
        }

        public async Task<string> Register(Guid id, EventRegisterSaveDto dto)
        {
            var eventUserRegisterRep = this._unitOfWork.GetRepositoryAsync<EventRegister>();
            var queryEvent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Event>().QueryAll();

            var objEvent = queryEvent.FirstOrDefault(x => x.Id == id);

            var newEventUserRegister = new EventRegister()
            {
                UserId = dto.UserId,
                EventId = id,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
            };

            await eventUserRegisterRep.Add(newEventUserRegister);
            await this._unitOfWork.SaveChangesAsync();

            EventRegisterNotificationJob.SetScopeFactory(this._scopeFactory);
            var emailInfo = new EmailInfoDto
            {
                Title = "[STM] Đăng ký tham gia sự kiện",
                EmailAddress = new List<string>() { newEventUserRegister.Email },
            };

            this._schedulingService.ScheduleJob<EventRegisterNotificationJob>(Guid.NewGuid().ToString(), DateTime.Now, new Dictionary<string, string>
                            {
                                { "EmailInfoAsJson", JsonConvert.SerializeObject(emailInfo) },
                                { "EventName", objEvent.Title },
                            });

            return Messages.EventRegister;
        }

        public async Task<MemoryStream> ExportExcel(EventSearchDto dto)
        {
            string templatePath = Path.Combine(Environment.CurrentDirectory, GlobalConstants.ResourceFolder, GlobalConstants.TemplateFolder);
            string reportPath = Path.Combine(Environment.CurrentDirectory, GlobalConstants.ResourceFolder, GlobalConstants.ReportFolder);
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }

            string fileName = string.Format(FileNameConstants.StatisticsEvent, DateTime.Now.ToString("yyyyMMddhhmmsss"));
            FileInfo newFile = new FileInfo(Path.Combine(reportPath, fileName));
            FileInfo templateFile = new FileInfo(Path.Combine(templatePath, FileNameConstants.StatisticsEventTemplate));

            var data = (await this.Search(dto)).ToList();

            using (ExcelPackage pck = new ExcelPackage(newFile, templateFile))
            {
                var row = 4;
                ExcelWorksheet sheet = pck.Workbook.Worksheets[0];
                foreach (var item in data)
                {
                    if (item.EndDate < DateTime.Now)
                    {
                        item.Status = StatusEnum.ExpiredDate;
                    }
                    else if (item.StartDate > DateTime.Now)
                    {
                        item.Status = StatusEnum.InComming;
                    }
                    else if (item.StartDate < DateTime.Now && DateTime.Now < item.EndDate)
                    {
                        item.Status = StatusEnum.InProgress;
                    }

                    sheet.Cells[$"B{row}"].Value = row - 3;
                    sheet.Cells[$"C{row}"].Value = EnumHelper<EventTypeEnum>.GetDisplayValue(item.Type);
                    sheet.Cells[$"D{row}"].Value = item.StartDate;
                    sheet.Cells[$"E{row}"].Value = item.EndDate;
                    sheet.Cells[$"F{row}"].Value = item.Status.HasValue ? EnumHelper<StatusEnum>.GetDisplayValue(item.Status.Value) : string.Empty;
                    sheet.Cells[$"G{row}"].Value = item.CountEventRegister;
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
