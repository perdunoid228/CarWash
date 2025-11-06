using CarWash.Domain.Common;
namespace CarWash.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public Guid ClientId { get; set; }
        public Guid CarId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Car Car { get; set; } = null!;
        public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
    }

    public enum OrderStatus
    {
        Pending,
        InProgress,
        Completed
    }
}