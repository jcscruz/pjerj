using Application.UseCases.Users.Commands.CreateUser;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Users.Commands
{
    public class CreateUserHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly CreateUserHandler _handler;

        public CreateUserHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new CreateUserHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateUserAndReturnUserId()
        {
            // Arrange
            var userId = 1L;
            var command = new CreateUserCommand(
                "John Doe",
                "johndoe@example.com",
                new DateOnly(1990, 1, 1),
                "System",
                "123456"
            );
            command.SetType(2); // Set TypeId in the command

            _userRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<UserEntity>()))
                .ReturnsAsync(userId);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _userRepositoryMock.Verify(repo => repo.AddAsync(It.Is<UserEntity>(user =>
                user.Name == command.Name &&
                user.EmailAddress == command.EmailAddress &&
                user.DateOfBirth == command.DateOfBirth &&
                user.Registration == command.Registration &&
                user.TypeId == command.TypeId
            )), Times.Once);

            response.Should().NotBeNull();
            response.UserId.Should().Be(userId);
        }
    }
}