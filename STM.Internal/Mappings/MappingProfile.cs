﻿namespace STM.API.Mappings
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using STM.API.Requests.Auth;
    using STM.API.Requests.Base;
    using STM.API.Requests.Roles;
    using STM.API.Requests.Settings;
    using STM.API.Requests.Tables;
    using STM.API.Requests.Users;
    using STM.API.Responses.Base;
    using STM.API.Responses.Roles;
    using STM.API.Responses.Settings;
    using STM.API.Responses.Tables;
    using STM.API.Responses.Users;
    using STM.DataTranferObjects.Auth;
    using STM.DataTranferObjects.Base;
    using STM.DataTranferObjects.Majors;
    using STM.DataTranferObjects.Roles;
    using STM.DataTranferObjects.Settings;
    using STM.DataTranferObjects.Users;
    using STM.ViewModels.Accounts;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Glbobal
            this.CreateMap<SelectListItemDto, SelectListItem>();
            this.CreateMap<PermissionDto, PermissionResponse>();
            this.CreateMap<PermissionMenuDto, PermissionMenuResponse>();
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
            this.CreateMap<MajorImportRequestDto, MajorImportDto>();
        }
    }
}
