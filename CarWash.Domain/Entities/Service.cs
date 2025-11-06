using CarWash.Domain.Common;
namespace CarWash.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();
    }
}