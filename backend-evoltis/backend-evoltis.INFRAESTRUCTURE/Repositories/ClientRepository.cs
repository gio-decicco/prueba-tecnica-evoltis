using backend_evoltis.DOMAIN.Entities;
using backend_evoltis.DOMAIN.Interfaces;
using backend_evoltis.INFRAESTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;

namespace backend_evoltis.INFRAESTRUCTURE.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly EvoltisContext _context;
        public ClientRepository(EvoltisContext context)
        {
            _context = context;
        }
        public async Task<Client> DeleteClient(Guid id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null) throw new NullReferenceException("the client with id " + id + " does not exist");
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> GetClientById(Guid id)
        {
            var client = await _context.Clients.Include(x => x.Services).ThenInclude(x => x.Service).FirstOrDefaultAsync(x => x.Id == id);
            if (client == null) throw new NullReferenceException("the client with id " + id + " does not exist");
            return client;
        }

        public async Task<List<Client>> GetClients(string? aprox, DateTime? dateCreatedFrom, DateTime? dateCreatedUntil, List<Guid>? services)
        {
            var query = _context.Clients.Include(x => x.Services).ThenInclude(x => x.Service).AsQueryable();
            if(aprox != string.Empty && aprox != null) query = query.Where(x => x.Name.StartsWith(aprox) || x.Surname.StartsWith(aprox) || x.Email.StartsWith(aprox));
            if(dateCreatedFrom.HasValue) query = query.Where(x => x.CreatedAt > dateCreatedFrom.Value);
            if(dateCreatedUntil.HasValue) query = query.Where(x => x.CreatedAt < dateCreatedUntil.Value);
            if (services.Count > 0) query = query.Where(x => x.Services.Any(y => services.Contains(y.Service.Id)));

            return await query.ToListAsync();
        }

        public async Task<Client> ModifyClient(Client client)
        {
            var result = _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Client> PostClient(Client client)
        {
            var result = await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
