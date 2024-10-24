using AutoMapper;
using backend_evoltis.CORE.Models.Clients.Requests;
using backend_evoltis.DOMAIN.Entities;
using backend_evoltis.DOMAIN.Interfaces;

namespace backend_evoltis.CORE.Services.Imp
{
    public class ClientsService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ClientsService(IClientRepository repository, IMapper mapper, IServiceRepository serviceRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<Client> DeleteClient(Guid id) => await _repository.DeleteClient(id);

        public async Task<Client> GetClientById(Guid id) => await _repository.GetClientById(id);

        public async Task<List<Client>> GetClients(
            string? aprox, 
            DateTime? dateCreatedFrom, 
            DateTime? dateCreatedUntil,
            List<Guid>? services
            ) => await _repository.GetClients(
                aprox, 
                dateCreatedFrom, 
                dateCreatedUntil,
                services
                );

        public async Task<Client> ModifyClient(Guid id, ClientRequest request)
        {
            var client = await _repository.GetClientById(id);
            client = _mapper.Map(request, client);
            client.Services = [];
            foreach (var serviceId in request.Services)
            {
                var service = await _serviceRepository.GetServiceById(serviceId);
                if (client.Services.Any(s => s.Service.Id == serviceId)) continue;
                var clientService = new ClientService
                {
                    Service = service,
                    Client = client
                };
                client.Services.Add(clientService);
            }
            client.ModifiedAt = DateTime.Now;
            return await _repository.ModifyClient(client);
        }

        public async Task<Client> PostClient(ClientRequest request)
        {
            var client = _mapper.Map<Client>(request);
            client.Services = [];
            foreach (var serviceId in request.Services)
            {
                var service = await _serviceRepository.GetServiceById(serviceId);
                var clientService = new ClientService
                {
                    Service = service,
                    Client = client
                };
                client.Services.Add(clientService);
            }
            client.ModifiedAt = DateTime.Now;
            return await _repository.PostClient(client);
        }
    }
}
