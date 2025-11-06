using CarWash.Domain.Common;
namespace CarWash.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;

        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}