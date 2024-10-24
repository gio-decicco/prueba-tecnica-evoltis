using backend_evoltis.DOMAIN.Entities;
using backend_evoltis.DOMAIN.Interfaces;
using backend_evoltis.INFRAESTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;

namespace backend_evoltis.INFRAESTRUCTURE.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly EvoltisContext _context;

        public ServiceRepository(EvoltisContext context)
        {
            _context = context;
        }

        public async Task<Service> DeleteService(Guid id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null) throw new NullReferenceException("The service with id " + id + " does not exist");
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service> GetServiceById(Guid id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null) throw new NullReferenceException("The service with id " + id + " does not exist");
            return service;
        }

        public async Task<List<Service>> GetServices(
            string? aprox, 
            DateTime? dateCreatedFrom, 
            DateTime? dateCreatedUntil, 
            decimal? priceMin, 
            decimal? priceMax)
        {
            var query = _context.Services.AsQueryable();
            if(aprox != string.Empty && aprox != null) query = query.Where(x => x.Description.StartsWith(aprox, StringComparison.CurrentCultureIgnoreCase));
            if(dateCreatedFrom.HasValue) query = query.Where(x => x.CreatedAt > dateCreatedFrom.Value);
            if(dateCreatedUntil.HasValue) query = query.Where(x => x.CreatedAt < dateCreatedUntil.Value);
            if(priceMin.HasValue) query = query.Where(x => x.Price > priceMin.Value);
            if(priceMax.HasValue) query = query.Where(x => x.Price < priceMax.Value);

            return await query.ToListAsync();
        }

        public async Task<Service> ModifyService(Service service)
        {
            var result = _context.Services.Update(service);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Service> PostService(Service service)
        {
            var result = await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
