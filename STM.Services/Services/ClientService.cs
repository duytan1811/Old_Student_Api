namespace STM.Services.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using STM.Common.Constants;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> IsAuthorize(string clientId, string clientSecret, string scope)
        {
            var repository = this._unitOfWork.GetRepositoryReadOnlyAsync<Client>();

            var clientIdint = Guid.Empty;

            if (!Guid.TryParse(clientId, out clientIdint))
            {
                return false;
            }

            var client = await repository.Single(i => i.ClientId == clientIdint && i.ClientSecret == clientSecret);

            if (client == null)
            {
                return false;
            }

            return client.ScopeArray.Any(i => i == scope || i.Equals(ClientScopeConstants.AllowAccessAll));
        }
    }
}
