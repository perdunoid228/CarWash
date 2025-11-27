using FluentAssertions;
using CarWash.Core.Entities;

namespace CarWash.Tests.Domain;

public class ServiceTests
{
    [Fact]
    public void Service_Create_ShouldHaveDefaultValues()
    {
        var service = new Service();

        service.Id.Should().Be(0);
        service.Name.Should().BeNull();
        service.Opisanie.Should().BeNull();
        service.Price.Should().Be(0);
        service.Orders.Should().NotBeNull();
    }

    [Fact]
    public void Service_WithCompleteData_ShouldSetAllProperties()
    {
        var service = new Service
        {
            Id = 1,
            Name = "Premium Wash",
            Opisanie = "Полная мойка с полировкой",
            Price = 1500
        };

        service.Id.Should().Be(1);
        service.Name.Should().Be("Premium Wash");
        service.Opisanie.Should().Be("Полная мойка с полировкой");
        service.Price.Should().Be(1500);
    }

    [Fact]
    public void Service_WithZeroPrice_ShouldBeAllowed()
    {
        var service = new Service { Price = 0 };

        service.Price.Should().Be(0);
    }

    [Fact]
    public void Service_AddOrder_ShouldAddOrderToCollection()
    {
        var service = new Service();
        var order = new Order { Id = 1 };

        service.Orders!.Add(order);

        service.Orders.Should().ContainSingle();
        service.Orders.First().Id.Should().Be(1);
    }
}