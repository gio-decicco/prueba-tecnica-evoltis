using AutoMapper;
using backend_evoltis.CORE.DTOs.Clients;
using backend_evoltis.CORE.DTOs.Services;
using backend_evoltis.CORE.Models.Clients.Commands;
using backend_evoltis.CORE.Models.Clients.Requests;
using backend_evoltis.CORE.Models.Services.Commands;
using backend_evoltis.CORE.Models.Services.Requests;
using backend_evoltis.DOMAIN.Entities;

namespace backend_evoltis.CORE.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //requests
            CreateMap<PostService_Command, ServiceRequest>();
            CreateMap<ModifyService_Command, ServiceRequest>();
            CreateMap<ServiceRequest, Service>();

            CreateMap<PostClient_Command, ClientRequest>();
            CreateMap<ModifyClient_Command, ClientRequest>();
            CreateMap<ClientRequest, Client>().ForMember(x => x.Services, opt => opt.Ignore());

            //responses
            CreateMap<Service, ServiceResponse>();
            CreateMap<Service, ServiceDto>();

            CreateMap<Client, ClientResponse>();
            CreateMap<ClientService, ServiceResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Service.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Service.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Service.Price))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.Service.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.Service.ModifiedAt ?? DateTime.Now));
            CreateMap<Client, ClientDto>();

        }
    }
}
