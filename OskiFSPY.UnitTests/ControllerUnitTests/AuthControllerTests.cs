using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OskiFSPY.Core.AuthJWT.AccessToken;
using OskiFSPY.Core.AuthJWT;
using OskiFSPY.WebAPI.Controllers;
using OskiFSPY.Core.AuthJWT.RefreshJWT;

namespace OskiFSPY.UnitTests.ControllerUnitTests;

public class AuthControllerTests
{
    [Fact]
    public async Task Login_WithValidCredentials_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new AuthController(mediatorMock.Object);
        var jwtCommand = new JwtCommand
        {
            Email = "test@example.com",
            Password = "password"
        };

        var tokens = new Tokens
        {
            AccessToken = "sample-access-token",
            RefreshToken = "sample-refresh-token"
        };
        mediatorMock.Setup(m => m.Send(jwtCommand, default)).ReturnsAsync(tokens);

        // Act
        var result = await controller.Login(jwtCommand);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task RefreshToken_WithValidRequest_Returns_OkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new AuthController(mediatorMock.Object);
        var refreshTokenCommand = new RefreshTokenCommand
        {
            UserId = 1,
            AccessToken = "sample-access-token",
            RefreshToken = "sample-refresh-token"
        };

        var tokens = new Tokens
        {
            AccessToken = "new-access-token",
            RefreshToken = "new-refresh-token"
        };
        mediatorMock.Setup(m => m.Send(refreshTokenCommand, default)).ReturnsAsync(tokens);

        // Act
        var result = await controller.RefreshToken(refreshTokenCommand);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
