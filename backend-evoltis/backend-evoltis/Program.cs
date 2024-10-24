using AutoMapper;
using backend_evoltis.CORE.Handlers.Clients;
using backend_evoltis.CORE.Handlers.Services;
using backend_evoltis.CORE.Services;
using backend_evoltis.CORE.Services.Imp;
using backend_evoltis.CORE.Utils;
using backend_evoltis.DOMAIN.Interfaces;
using backend_evoltis.INFRAESTRUCTURE.Context;
using backend_evoltis.INFRAESTRUCTURE.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();
        p.AllowAnyOrigin();
    });
});

builder.Services.AddValidatorsFromAssemblyContaining<DeleteClient_Business>();
builder.Services.AddValidatorsFromAssemblyContaining<ModifyClient_Business>();
builder.Services.AddValidatorsFromAssemblyContaining<PostClient_Business>();
builder.Services.AddValidatorsFromAssemblyContaining<GetClientById_Business>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteService_Business>();
builder.Services.AddValidatorsFromAssemblyContaining<ModifyService_Business>();
builder.Services.AddValidatorsFromAssemblyContaining<PostService_Business>();
builder.Services.AddValidatorsFromAssemblyContaining<GetServiceById_Business>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EvoltisContext>(opt =>
{
    opt.UseMySQL(builder.Configuration.GetConnectionString("EvoltisDb"));
});

var mapperConfiguration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteClient_Business).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModifyClient_Business).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PostClient_Business).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetClientById_Business).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetClients_Business).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteService_Business).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModifyService_Business).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PostService_Business).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetServiceById_Business).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetServices_Business).Assembly));

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddTransient<IServicesService, ServicesService>();
builder.Services.AddTransient<IClientService, ClientsService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
