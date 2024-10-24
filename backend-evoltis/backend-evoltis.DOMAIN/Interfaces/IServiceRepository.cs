using backend_evoltis.DOMAIN.Entities;

namespace backend_evoltis.DOMAIN.Interfaces
{
    public interface IServiceRepository
    {
        public Task<List<Service>> GetServices(
            string? aprox, 
            DateTime? dateCreatedFrom, 
            DateTime? dateCreatedUntil, 
            decimal? priceMin, 
            decimal? priceMax);
        public Task<Service> GetServiceById(Guid id);
        public Task<Service> PostService(Service service);
        public Task<Service> ModifyService(Service service);
        public Task<Service> DeleteService(Guid id);
    }
}
