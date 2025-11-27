using FluentAssertions;
using CarWash.Core.Entities;

namespace CarWash.Tests.Domain;

public class OrderTests
{
    [Fact]
    public void Order_Create_ShouldInitializeWithDefaultValues()
    {
        var order = new Order();

        order.Id.Should().Be(0);
        order.UserId.Should().Be(0);
        order.CarId.Should().Be(0);
        order.ServiceId.Should().Be(0);
        order.OrderDate.Should().Be(DateTime.MinValue);
        order.Status.Should().BeEmpty();
        order.User.Should().BeNull();
        order.Car.Should().BeNull();
        order.Service.Should().BeNull();
    }

    [Fact]
    public void Order_WithRelations_ShouldSetNavigationProperties()
    {
        var user = new User { Id = 1 };
        var car = new Car { Id = 1 };
        var service = new Service { Id = 1 };

        var order = new Order
        {
            User = user,
            Car = car,
            Service = service
        };

        order.User.Should().Be(user);
        order.Car.Should().Be(car);
        order.Service.Should().Be(service);
    }

    [Theory]
    [InlineData("Pending")]
    [InlineData("In Progress")]
    [InlineData("Completed")]
    [InlineData("Cancelled")]
    public void Order_WithDifferentStatuses_ShouldBeValid(string status)
    {
        var order = new Order { Status = status };

        order.Status.Should().Be(status);
    }

    [Fact]
    public void Order_WithForeignKeys_ShouldSetIdsCorrectly()
    {
        var user = new User { Id = 1 };
        var car = new Car { Id = 2 };
        var service = new Service { Id = 3 };

        var order = new Order
        {
            UserId = 1,
            CarId = 2,
            ServiceId = 3,
            User = user,
            Car = car,
            Service = service
        };

        order.UserId.Should().Be(1);
        order.CarId.Should().Be(2);
        order.ServiceId.Should().Be(3);
    }
}