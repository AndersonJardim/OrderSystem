using System.Threading.Tasks;
using Xunit;
using Order.Dispatch.Application.Services;
using FluentAssertions;

namespace Order.Dispatch.Tests.Services;

public class OrderDispatchServiceTests
{
    [Fact]
    public async Task DispatchAsync_ShouldCompleteSuccessfully()
    {
        // Arrange
        var service = new OrderDispatchService();
        var sampleMessage = "pedido-teste-123";

        // Act
        var act = () => service.DispatchAsync(sampleMessage);

        // Assert
        await act.Should().NotThrowAsync();
    }
}
