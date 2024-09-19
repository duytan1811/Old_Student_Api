namespace STM.Services.IServices
{
    using System.Threading.Tasks;

    public interface IClientService
    {
        Task<bool> IsAuthorize(string clientId, string clientSecret, string scope);
    }
}
