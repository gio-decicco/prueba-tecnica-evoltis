namespace backend_evoltis.DOMAIN.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; } = DateTime.Now;
    }
}
