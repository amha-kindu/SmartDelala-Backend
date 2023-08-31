using System.Threading;
using System.Threading.Tasks;
using Moq;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Features.Auth.Commands;
using SmartDelala.Application.Features.Auth.Handlers;
using SmartDelala.Application.Responses;
using SmartDelala.Application.UnitTests.Mocks;
using Xunit;

namespace SmartDelala.UnitTests.Users
{
    public class LoginCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResponse()
        {
            
            var userRepositoryMock = new MockUserRepository();
            var command = new LoginCommand
            {
                LoginRequest = new LoginRequest("1234567890")
            };

            var loggedInUser = new LoginResponse
            ("User logged in successfully",
                 "access_token",
                 "refresh_token"
            );

            userRepositoryMock.Setup(u => u.LoginAsync(command.LoginRequest.PhoneNumber)).ReturnsAsync(loggedInUser);
            var handler = new LoginCommandHandler(userRepositoryMock.Object);

            
            var response = await handler.Handle(command, CancellationToken.None);

       
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal("Logged In Successfully", response.Message);
            Assert.NotNull(response.Value);
            Assert.Equal(loggedInUser.Message, response.Value.Message);
            Assert.Equal(loggedInUser.AccessToken, response.Value.AccessToken);
            Assert.Equal(loggedInUser.refreshToken, response.Value.refreshToken);
        }
    }
}
