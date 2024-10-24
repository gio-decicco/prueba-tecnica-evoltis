using AutoMapper;
using backend_evoltis.CORE.Models.Services.Requests;
using backend_evoltis.DOMAIN.Entities;
using backend_evoltis.DOMAIN.Interfaces;

namespace backend_evoltis.CORE.Services.Imp
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        public ServicesService(IServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Service> DeleteService(Guid id) => await _repository.DeleteService(id);

        public async Task<Service> GetServiceById(Guid id) => await _repository.GetServiceById(id);

        public async Task<List<Service>> GetServices(
            string? aprox, 
            DateTime? dateCreatedFrom, 
            DateTime? dateCreatedUntil, 
            decimal? priceMin, 
            decimal? priceMax) => await _repository.GetServices(
                aprox, 
                dateCreatedFrom, 
                dateCreatedUntil, 
                priceMin, 
                priceMax
                );

        public async Task<Service> ModifyService(Guid id, ServiceRequest request)
        {
            var service = await _repository.GetServiceById(id);
            service = _mapper.Map(request, service);
            service.ModifiedAt = DateTime.Now;
            return await _repository.ModifyService(service);
        }

        public async Task<Service> PostService(ServiceRequest request)
        {
            var service = _mapper.Map<Service>(request);
            service.ModifiedAt = DateTime.Now;
            return await _repository.PostService(service);
        }
    }
}
