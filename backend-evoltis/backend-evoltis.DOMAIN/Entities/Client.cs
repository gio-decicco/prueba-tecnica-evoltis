namespace backend_evoltis.DOMAIN.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime?  ModifiedAt { get; set; }
        public List<ClientService> Services { get; set; }
    }
}
