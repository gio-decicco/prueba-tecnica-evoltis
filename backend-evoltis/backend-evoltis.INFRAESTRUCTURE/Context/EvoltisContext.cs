using backend_evoltis.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_evoltis.INFRAESTRUCTURE.Context
{
    public class EvoltisContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ClientService> ClientServices { get; set; }

        public EvoltisContext() { }
        public EvoltisContext(DbContextOptions<EvoltisContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = Guid.NewGuid(), Description = "Web Hosting Service", Price = 1200 },
                new Service { Id = Guid.NewGuid(), Description = "Cloud Storage Solutions", Price = 3000 },
                new Service { Id = Guid.NewGuid(), Description = "Cybersecurity Monitoring", Price = 4500 },
                new Service { Id = Guid.NewGuid(), Description = "Managed IT Support", Price = 2500 },
                new Service { Id = Guid.NewGuid(), Description = "Custom Software Development", Price = 6000 }
            );
        }
    }
}
