using backend_evoltis.CORE.Models.Services.Requests;
using backend_evoltis.DOMAIN.Entities;

namespace backend_evoltis.CORE.Services
{
    public interface IServicesService
    {
        public Task<Service> PostService(ServiceRequest request);
        public Task<Service> ModifyService(Guid id, ServiceRequest request);
        public Task<List<Service>> GetServices(
            string? aprox, 
            DateTime? dateCreatedFrom, 
            DateTime? dateCreatedUntil, 
            decimal? priceMin, 
            decimal? priceMax);
        public Task<Service> GetServiceById(Guid id);
        public Task<Service> DeleteService(Guid id);
    }
}
