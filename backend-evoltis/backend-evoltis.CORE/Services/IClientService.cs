using backend_evoltis.CORE.Models.Clients.Requests;
using backend_evoltis.DOMAIN.Entities;

namespace backend_evoltis.CORE.Services
{
    public interface IClientService
    {
        public Task<Client> PostClient(ClientRequest request);
        public Task<Client> ModifyClient(Guid id, ClientRequest request);
        public Task<List<Client>> GetClients(string? aprox, DateTime? dateCreatedFrom, DateTime? dateCreatedUntil, List<Guid>? services);
        public Task<Client> GetClientById(Guid id);
        public Task<Client> DeleteClient(Guid id);
    }
}
