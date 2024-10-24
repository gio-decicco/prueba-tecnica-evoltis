using backend_evoltis.CORE.Models;

namespace backend_evoltis.CORE.DTOs.Services
{
    public class ServiceDto : BaseResult
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
