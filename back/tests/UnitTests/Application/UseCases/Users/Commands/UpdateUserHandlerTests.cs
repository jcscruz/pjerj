using Application.UseCases.Users.Commands.UpdateUser;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Users.Commands
{
    public class UpdateUserHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UpdateUserHandler _handler;

        public UpdateUserHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new UpdateUserHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateUserAndReturnSuccess()
        {
            // Arrange
            var command = new UpdateUserCommand
            {
                Name = "John Doe",
                EmailAddress = "johndoe@example.com",
                Registration = "123456",
                DateOfBirth = new DateOnly(1990, 1, 1),
                Origin = "System",
            };
            command.SetUserId(1); // Set UserId in the command
            command.SetTypeId(2); // Set TypeId in the command

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _userRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<UserEntity>(user =>
                user.Name == command.Name &&
                user.EmailAddress == command.EmailAddress &&
                user.Registration == command.Registration &&
                user.DateOfBirth == command.DateOfBirth &&
                user.Id == command.UserId &&
                user.TypeId == command.TypeId
            )), Times.Once);

            response.Should().NotBeNull();
            response.Success.Should().BeTrue();
        }
    }
}