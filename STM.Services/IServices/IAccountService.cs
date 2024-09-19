namespace STM.Services.IServices
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using STM.DataTranferObjects.Auth;
    using STM.DataTranferObjects.Token;

    public interface IAccountService
    {
        Task<TokenDto> GenerateToken(string username);

        Task<CurrentUserDto?> GetCurrentUser(ClaimsPrincipal user);

        void SetCurrentUser(Guid? currentUserId);
    }
}
