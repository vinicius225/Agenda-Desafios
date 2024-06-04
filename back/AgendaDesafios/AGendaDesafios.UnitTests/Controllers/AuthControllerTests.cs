

using AgendaDesafios.Application.DTOs;
using AgendaDesafios.Application.Login.Queries;
using AgendaDesafios.WebAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using AgendaDesafios.WebAPI.Responses;

namespace AGendaDesafios.UnitTests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly AuthController _authController;

        public AuthControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _authController = new AuthController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Authentication_ShouldReturnOk_WhenValidRequest()
        {
            // Arrange
            var authUserQuery = new AuthUserQuery { Login = "testuser", Password = "testpass" };
            var authResponse = new AuthDTO { token = "sampleToken", Name = "xpto", email = "xpto.com" };

            _mediatorMock.Setup(m => m.Send(authUserQuery, default))
                         .ReturnsAsync(authResponse);

            // Act
            var result = await _authController.Authentication(authUserQuery);

            // Assert
            var okResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
            var response = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal("Sucesso", response.Message);
            Assert.Equal(authResponse, response.Data);
        }

        [Fact]
        public async Task Authentication_ShouldReturnBadRequest_WhenInvalidRequest()
        {
            // Arrange
            var authUserQuery = new AuthUserQuery { Login = "testuser", Password = "testpass" };

            _mediatorMock.Setup(m => m.Send(authUserQuery, default))
                         .ReturnsAsync((AuthDTO)null);

            // Act
            var result = await _authController.Authentication(authUserQuery);

            // Assert
            var badRequestResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
            var response = Assert.IsType<dynamic>(badRequestResult.Value);
            Assert.Equal("Parametros invalidos", response.Message);
        }

    }
}
