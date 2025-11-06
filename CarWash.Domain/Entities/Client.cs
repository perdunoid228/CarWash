using CarWash.Domain.Common;
namespace CarWash.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}