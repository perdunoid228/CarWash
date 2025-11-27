namespace CarWash.Core.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    public int ServiceId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    
    public User? User { get; set; }
    public Car? Car { get; set; }
    public Service? Service { get; set; }
}