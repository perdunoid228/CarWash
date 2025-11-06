using CarWash.Domain.Common;
namespace CarWash.Domain.Entities
{
    public class OrderService : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ServiceId { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}