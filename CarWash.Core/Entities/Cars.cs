using System.Collections.Generic;


namespace CarWash.Core.Entities;

public class Car
{
    public int Id { get; set; }
    public string? Marka { get; set; }
    public string? Model { get; set; }
    public string? Number { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public List<Order>? Order { get; set; } = new();
}
