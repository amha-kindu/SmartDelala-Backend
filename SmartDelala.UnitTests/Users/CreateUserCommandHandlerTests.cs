using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SmartDelala.Application.Common.Dtos.Security;
using SmartDelala.Application.Features.Auth.Commands;
using SmartDelala.Application.Features.Auth.Handlers;
using SmartDelala.Application.Responses;
using SmartDelala.Application.UnitTests.Mocks;
using SmartDelala.Domain.Models;
using Xunit;
namespace SmartDelala.UnitTests.Users

{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var userRepositoryMock = new MockUserRepository();
            var mapperMock = new Mock<IMapper>();

            var handler = new CreateUserCommandHandler(userRepositoryMock.Object, mapperMock.Object);

            var command = new CreateUserCommand
            {
                UserCreationDto = new UserCreationDto
                {
                    
                    Roles = new RoleDto
                    { Id = "role1", Name = "Role 1" },
                    FullName = "testuser",
                    PhoneNumber = "+251123456789",
                    Age = 30
                }
            };


            var expectedUser = new ApplicationUser();
            var expectedUserDto = new UserDto();
            mapperMock.Setup(mapper => mapper.Map<ApplicationUser>(command.UserCreationDto)).Returns(expectedUser);
            mapperMock.Setup(mapper => mapper.Map<UserDto>(expectedUser)).Returns(expectedUserDto);


            var response = await handler.Handle(command, CancellationToken.None);

            Assert.True(response.Success);
            Assert.Equal(expectedUserDto, response.Value);
        }
    }
}
