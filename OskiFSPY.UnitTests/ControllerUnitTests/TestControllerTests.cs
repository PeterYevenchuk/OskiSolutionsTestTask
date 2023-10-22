using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OskiFSPY.Core.Tests;
using OskiFSPY.Core.Tests.Get;
using OskiFSPY.Core.Tests.PassingTests;
using OskiFSPY.Core.UsersTestsStatuses;
using OskiFSPY.WebAPI.Controllers;

namespace OskiFSPY.UnitTests.ControllerUnitTests;

public class TestControllerTests
{
    [Fact]
    public async Task GetTest_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new TestController(mediatorMock.Object);
        var testId = 1;
        var userId = 1;
        var query = new GetFullTestQuery { TestId = testId, UserId = userId };
        var fullTest = new FullTest();

        mediatorMock.Setup(m => m.Send(It.IsAny<GetFullTestQuery>(), default)).ReturnsAsync(fullTest);

        // Act
        var result = await controller.GetTest(testId, userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<FullTest>(okResult.Value);
        Assert.Equal(fullTest, model);
    }

    [Fact]
    public async Task PassingTest_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new TestController(mediatorMock.Object);
        var query = new PassingTestCommand { UserId = 1, TestId = 1, QuestionAndAnswer = new Dictionary<int, int>() };
        var userTestStatusResponse = new UserTestStatusResponse();

        mediatorMock.Setup(m => m.Send(It.IsAny<PassingTestCommand>(), default)).ReturnsAsync(userTestStatusResponse);

        // Act
        var result = await controller.PassingTest(query);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<UserTestStatusResponse>(okResult.Value);
        Assert.Equal(userTestStatusResponse, model);
    }
}
