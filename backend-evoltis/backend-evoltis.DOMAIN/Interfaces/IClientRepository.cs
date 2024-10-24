using backend_evoltis.DOMAIN.Entities;

namespace backend_evoltis.DOMAIN.Interfaces
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetClients(string? aprox, DateTime? dateCreatedFrom, DateTime? dateCreatedUntil, List<Guid>? services);
        public Task<Client> GetClientById(Guid id);
        public Task<Client> PostClient(Client client);
        public Task<Client> ModifyClient(Client client);
        public Task<Client> DeleteClient(Guid id);
    }
}
