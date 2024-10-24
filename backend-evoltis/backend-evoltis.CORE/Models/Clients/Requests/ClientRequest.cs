namespace backend_evoltis.CORE.Models.Clients.Requests
{
    public class ClientRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<Guid> Services { get; set; }
    }
}
