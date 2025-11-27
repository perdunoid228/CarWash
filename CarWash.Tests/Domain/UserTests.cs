using FluentAssertions;
using CarWash.Core.Entities;

namespace CarWash.Tests.Domain;

public class UserTests
{
    [Fact]
    public void User_Create_ShouldInitializeProperties()
    {
        var user = new User
        {
            Id = 1,
            Name = "John Doe",
            Number = "+1234567890"
        };

        user.Id.Should().Be(1);
        user.Name.Should().Be("John Doe");
        user.Number.Should().Be("+1234567890");
        user.Cars.Should().NotBeNull();
        user.Order.Should().NotBeNull();
    }

    [Fact]
    public void User_AddCar_ShouldAddCarToCollection()
    {
        var user = new User();
        var car = new Car { Id = 1, Marka = "Toyota", Model = "Camry" };

        user.Cars!.Add(car);

        user.Cars.Should().ContainSingle();
        user.Cars.First().Marka.Should().Be("Toyota");
        user.Cars.First().Model.Should().Be("Camry");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("Valid Name")]
    public void User_WithDifferentNames_ShouldBeValid(string name)
    {
        var user = new User { Name = name };

        user.Name.Should().Be(name);
    }

    [Fact]
    public void User_AddOrder_ShouldAddOrderToCollection()
    {
        var user = new User();
        var order = new Order { Id = 1, Status = "Pending" };

        user.Order!.Add(order);

        user.Order.Should().ContainSingle();
        user.Order.First().Status.Should().Be("Pending");
    }
}