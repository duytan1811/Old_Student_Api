namespace STM.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Account;
    using STM.DataTranferObjects.Auth;
    using STM.DataTranferObjects.Roles;
    using STM.DataTranferObjects.Token;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AccountService(IUnitOfWork unitOfWork, UserManager<User> userManager, IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            this._configuration = configuration;
            this._userManager = userManager;
        }

        public async Task<TokenDto> GenerateToken(string username)
        {
            var queryStudent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Student>().QueryAll();
            var queryUserRole = await this._unitOfWork.GetRepositoryReadOnlyAsync<UserRole>().QueryAll();
            var queryRoleClaim = await this._unitOfWork.GetRepositoryReadOnlyAsync<RoleClaim>().QueryAll();

            var authClaims = new List<Claim>();

            var user = await this._userManager.FindByNameAsync(username);

            if (user == null)
            {
                return new TokenDto();
            }

            this._unitOfWork.CurrentUserEntityId = user.Id;
            user.LastLogin = DateTime.Now;
            await this._unitOfWork.SaveChangesAsync();

            var userInfo = await this.GetUserInfo(user);
            userInfo.Id = user.Id;
            userInfo.IsAdmin = user.IsAdmin;
            userInfo.IsTeacher = user.IsTeacher;
            userInfo.Username = username;

            if (userInfo.IsAdmin)
            {
                userInfo.FullName = "Admin";
            }
            else if (!userInfo.IsAdmin)
            {
                var student = queryStudent.FirstOrDefault(x => x.UserId == user.Id);
                if (student != null)
                {
                    userInfo.FullName = student.FullName;
                    userInfo.Phone = student.Phone;
                    userInfo.Email = student.Email;
                    userInfo.StudentId = student.Id;
                }
            }

            var roleIds = queryUserRole.Where(x => x.UserId == user.Id).Select(x => x.RoleId).Distinct().ToList();

            var roleClaims = queryRoleClaim.Where(x => roleIds.Contains(x.RoleId)).Select(x => new RoleClaimDto
            {
                ClaimValue = x.ClaimValue,
                ClaimType = x.ClaimType,
            }).ToList();

            var menuPermissions = this.GetMenuPermissions(roleClaims);
            userInfo.MenuPermissions = menuPermissions;

            authClaims.Add(new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(userInfo)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(CacheSettings.TokenExpirationTime),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return new TokenDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo.ToLocalTime(),
            };
        }

        public async Task<CurrentUserDto?> GetCurrentUser(ClaimsPrincipal user)
        {
            var currentUser = await this._userManager.GetUserAsync(user);
            if (currentUser == null)
            {
                return null;
            }

            var result = new CurrentUserDto
            {
                Id = currentUser.Id,
                UserName = currentUser.UserName,
                Email = currentUser.Email,
            };

            return result;
        }

        public void SetCurrentUser(Guid? currentUserId)
        {
            this._unitOfWork.CurrentUserEntityId = currentUserId;
        }

        private async Task<UserInfoDto> GetUserInfo(User user)
        {
            var roleRepository = this._unitOfWork.GetRepositoryReadOnlyAsync<Role>();
            var userInfo = new UserInfoDto();

            var roleIds = (await roleRepository.QueryCondition(i => i.UserRoles.Any(i => i.IsActive == true && i.UserId == user.Id))).Select(i => i.Id).ToList();

            return userInfo;
        }

        private List<MenuPermissionDto> GetMenuPermissions(List<RoleClaimDto> roleClaims)
        {
            var menuPermissions = new List<MenuPermissionDto>();

            if (roleClaims.Count > 0)
            {
                var claimTypes = roleClaims.Select(x => x.ClaimType).Distinct().ToList();

                foreach (var claimType in claimTypes)
                {
                    var items = roleClaims.Where(x => x.ClaimType == claimType).ToList();
                    var newData = new MenuPermissionDto()
                    {
                        ClaimType = claimType,
                        IsView = items.Exists(x => x.ClaimValue == "1"),
                        IsCreate = items.Exists(x => x.ClaimValue == "2"),
                        IsEdit = items.Exists(x => x.ClaimValue == "3"),
                        IsDelete = items.Exists(x => x.ClaimValue == "4"),
                    };

                    menuPermissions.Add(newData);
                }
            }

            return menuPermissions;
        }
    }
}