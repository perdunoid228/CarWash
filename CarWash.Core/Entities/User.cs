using System.Collections.Generic;

namespace CarWash.Core.Entities;
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Number { get; set; }
    public List<Car>? Cars { get; set; } = new();
    public List<Order>? Order { get; set; } = new();
}
