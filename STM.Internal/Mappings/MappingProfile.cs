namespace STM.API.Mappings
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Newtonsoft.Json;
    using STM.API.Requests.Auth;
    using STM.API.Requests.Base;
    using STM.API.Requests.Events;
    using STM.API.Requests.Fourms;
    using STM.API.Requests.Jobs;
    using STM.API.Requests.Majors;
    using STM.API.Requests.News;
    using STM.API.Requests.Roles;
    using STM.API.Requests.Settings;
    using STM.API.Requests.StudentAchievements;
    using STM.API.Requests.Students;
    using STM.API.Requests.Users;
    using STM.API.Responses.Base;
    using STM.API.Responses.Events;
    using STM.API.Responses.Fourms;
    using STM.API.Responses.Jobs;
    using STM.API.Responses.Majors;
    using STM.API.Responses.News;
    using STM.API.Responses.Roles;
    using STM.API.Responses.Settings;
    using STM.API.Responses.Statistics;
    using STM.API.Responses.StudentAchievements;
    using STM.API.Responses.Students;
    using STM.API.Responses.Users;
    using STM.Common.Enums;
    using STM.Common.Utilities;
    using STM.DataTranferObjects.Auth;
    using STM.DataTranferObjects.Base;
    using STM.DataTranferObjects.Events;
    using STM.DataTranferObjects.Fourms;
    using STM.DataTranferObjects.Jobs;
    using STM.DataTranferObjects.Majors;
    using STM.DataTranferObjects.News;
    using STM.DataTranferObjects.Roles;
    using STM.DataTranferObjects.Settings;
    using STM.DataTranferObjects.Statistics;
    using STM.DataTranferObjects.StudentAchievements;
    using STM.DataTranferObjects.Students;
    using STM.DataTranferObjects.Users;
    using STM.Entities.Models;
    using STM.ViewModels.Accounts;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Glbobal
            this.CreateMap<SelectListItemDto, SelectListItem>();
            this.CreateMap<PermissionDto, PermissionResponse>();
            this.CreateMap<PermissionRequest, PermissionDto>();

            // Login
            this.CreateMap<LoginRequest, LoginDto>();

            // User
            this.CreateMap<UserDto, UserResponse>();
            this.CreateMap<UserSaveRequest, UserSaveDto>();
            this.CreateMap<CurrentUserViewModel, UserResponse>();
            this.CreateMap<UserSearchRequest, UserSearchDto>();

            // Role
            this.CreateMap<RoleSearchRequest, RoleSearchDto>();
            this.CreateMap<RoleSaveRequest, RoleSaveDto>();
            this.CreateMap<RoleDto, RoleResponse>();

            // User Role
            this.CreateMap<UserRoleSaveRequest, UserRoleSaveDto>();
            this.CreateMap<UserRoleDto, UserRoleResponse>();

            // Setting
            this.CreateMap<SettingSaveRequest, SettingSaveDto>();
            this.CreateMap<SettingDto, SettingResponse>();

            // Major
            this.CreateMap<MajorSaveRequestDto, MajorSaveDto>();
            this.CreateMap<MajorSearchRequestDto, MajorSearchDto>();
            this.CreateMap<MajorDto, MajorResponseDto>();

            // Student
            this.CreateMap<StudentSaveRequestDto, StudentSaveDto>();
            this.CreateMap<StudentSearchRequestDto, StudentSearchDto>();
            this.CreateMap<Student, StudentDto>().ForMember(x => x.MajorName, m => m.MapFrom(s => s.MajorId.HasValue ? s.Major.Name : string.Empty))
                .ForMember(x => x.CountArchievement, opt => opt.MapFrom(x => x.StudentAchievements.Count));
            this.CreateMap<StudentDto, StudentResponseDto>();

            // Student achievement
            this.CreateMap<StudentAchievementSaveRequestDto, StudentAchievementSaveDto>();
            this.CreateMap<StudentAchievementSearchRequestDto, StudentAchievementSearchDto>();
            this.CreateMap<StudentAchievement, StudentAchievementDto>();
            this.CreateMap<StudentAchievementDto, StudentAchievementResponseDto>();

            this.CreateMap<NewsSaveRequestDto, NewsSaveDto>();
            this.CreateMap<News, NewsDto>().ForMember(x => x.Type, opt => opt.MapFrom(t => EnumHelper<NewsTypeEnum>.GetValues(t.Type)));
            this.CreateMap<NewsSearchRequestDto, NewsSearchDto>();
            this.CreateMap<NewsDto, NewsResponseDto>();

            this.CreateMap<FourmSearchRequestDto, FourmSearchDto>();
            this.CreateMap<FourmDto, FourmResponseDto>();
            this.CreateMap<NewsComment, CommentDto>()
                .ForMember(x => x.UserAvatar, opt => opt.MapFrom(s => s.User.IsAdmin ? string.Empty : s.User.Student.Avatar));

            this.CreateMap<CommentSaveRequestDto, CommentSaveDto>();
            this.CreateMap<CommentDto, CommentResponseDto>();
            this.CreateMap<CommentSearchRequestDto, CommentSearchDto>();

            this.CreateMap<JobSaveRequestDto, JobSaveDto>();
            this.CreateMap<JobSearchRequestDto, JobSearchDto>();
            this.CreateMap<Job, JobDto>()
               .ForMember(x => x.Skills, opt => opt.MapFrom(t => JsonConvert.DeserializeObject<List<string>>(t.Skills)))
                .ForMember(x => x.MajorName, opt => opt.MapFrom(t => t.Major.Name));
            this.CreateMap<JobDto, JobResponseDto>();
            this.CreateMap<ApplyJobSaveRequestDto, ApplyJobSaveDto>();
            this.CreateMap<UserApplySearchRequestDto, UserApplySearchDto>();
            this.CreateMap<UserApplyDto, UserApplyResponseDto>();

            this.CreateMap<EventSaveRequestDto, EventSaveDto>();
            this.CreateMap<EventSearchRequestDto, EventSearchDto>();
            this.CreateMap<Event, EventDto>();
            this.CreateMap<EventDto, EventResponseDto>();

            this.CreateMap<EventRegister, EventRegisterDto>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(i => i.User.Student.FullName));
            this.CreateMap<EventRegisterDto, EventRegisterResponseDto>();
            this.CreateMap<EventRegisterSearchRequestDto, EventRegisterSearchDto>();
            this.CreateMap<EventRegisterSaveRequestDto, EventRegisterSaveDto>();

            this.CreateMap<EventByMonthDto, EventByMonthResponseDto>();
            this.CreateMap<MemberByMonthDto, MemberByMonthResponseDto>();
            this.CreateMap<NewsByMonthDto, NewsByMonthResponseDto>();
        }
    }
}
