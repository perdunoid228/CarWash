using FluentAssertions;
using CarWash.Core.Entities;

namespace CarWash.Tests.Domain;

public class RelationshipTests
{
    [Fact]
    public void UserCarRelationship_ShouldWorkCorrectly()
    {
        var user = new User { Id = 1 };
        var car1 = new Car { Id = 1, UserId = 1 };
        var car2 = new Car { Id = 2, UserId = 1 };

        user.Cars.Add(car1);
        user.Cars.Add(car2);

        user.Cars.Should().HaveCount(2);
        user.Cars.Should().Contain(car1);
        user.Cars.Should().Contain(car2);
    }

    [Fact]
    public void UserOrderRelationship_ShouldWorkCorrectly()
    {
        var user = new User { Id = 1 };
        var order = new Order { Id = 1, UserId = 1 };

        user.Order.Add(order);

        user.Order.Should().ContainSingle();
        user.Order.First().Should().Be(order);
    }

    [Fact]
    public void CompleteOrderScenario_ShouldMaintainRelations()
    {
        var user = new User { Id = 1, Name = "Test User" };
        var car = new Car { Id = 1, Model = "Test Car", UserId = 1 };
        var service = new Service { Id = 1, Name = "Test Service", Price = 1000 };
        var order = new Order 
        { 
            Id = 1, 
            UserId = 1, 
            CarId = 1, 
            ServiceId = 1,
            User = user,
            Car = car,
            Service = service
        };

        user.Cars.Add(car);
        user.Order.Add(order);

        user.Cars.Should().Contain(car);
        user.Order.Should().Contain(order);
        order.User.Should().Be(user);
        order.Car.Should().Be(car);
        order.Service.Should().Be(service);
    }
}