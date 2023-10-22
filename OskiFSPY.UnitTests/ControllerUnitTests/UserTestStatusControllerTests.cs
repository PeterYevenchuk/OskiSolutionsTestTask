using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OskiFSPY.Core.UsersTestsStatuses;
using OskiFSPY.Core.UsersTestsStatuses.Get;
using OskiFSPY.Core.UsersTestsStatuses.GetAvailableTests;
using OskiFSPY.WebAPI.Controllers;

namespace OskiFSPY.UnitTests.ControllerUnitTests;

public class UserTestStatusControllerTests
{
    [Fact]
    public async Task GetUserTests_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new UserTestStatusController(mediatorMock.Object);
        var userId = 1;
        var userTestStatusResponses = new List<UserTestStatusResponse>();

        mediatorMock.Setup(m => m.Send(It.IsAny<GetUserTestQuery>(), default)).ReturnsAsync(userTestStatusResponses);

        // Act
        var result = await controller.GetUserTests(userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<List<UserTestStatusResponse>>(okResult.Value);
        Assert.Equal(userTestStatusResponses, model);
    }

    [Fact]
    public async Task PassingTest_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new UserTestStatusController(mediatorMock.Object);
        var userId = 1;
        var isPassed = true;
        var userTestStatusResponses = new List<UserTestStatusResponse>();

        mediatorMock.Setup(m => m.Send(It.IsAny<GetUserIsPassedTestQuery>(), default)).ReturnsAsync(userTestStatusResponses);

        // Act
        var result = await controller.PassingTest(userId, isPassed);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<List<UserTestStatusResponse>>(okResult.Value);
        Assert.Equal(userTestStatusResponses, model);
    }
}
