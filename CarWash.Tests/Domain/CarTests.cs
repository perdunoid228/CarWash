using FluentAssertions;
using CarWash.Core.Entities;

namespace CarWash.Tests.Domain;

public class CarTests
{
    [Fact]
    public void Car_Create_ShouldInitializeWithDefaultValues()
    {
        var car = new Car();

        car.Id.Should().Be(0);
        car.Marka.Should().BeNull();
        car.Model.Should().BeNull();
        car.Number.Should().BeNull();
        car.UserId.Should().Be(0);
        car.Order.Should().NotBeNull();
    }

    [Fact]
    public void Car_WithValidData_ShouldSetPropertiesCorrectly()
    {
        var user = new User { Id = 1 };

        var car = new Car
        {
            Id = 1,
            Marka = "BMW",
            Model = "X5",
            Number = "A123BC",
            UserId = 1,
            User = user
        };

        car.Id.Should().Be(1);
        car.Marka.Should().Be("BMW");
        car.Model.Should().Be("X5");
        car.Number.Should().Be("A123BC");
        car.UserId.Should().Be(1);
        car.User.Should().Be(user);
    }

    [Fact]
    public void Car_AddOrder_ShouldAddOrderToCollection()
    {
        var car = new Car();
        var order = new Order { Id = 1 };

        car.Order!.Add(order);

        car.Order.Should().ContainSingle();
        car.Order.First().Id.Should().Be(1);
    }
}