using Application.UseCases.Users.Commands.DeleteUser;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Users.Commands
{
    public class DeleteUserHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly DeleteUserHandler _handler;

        public DeleteUserHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new DeleteUserHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteUserAndReturnSuccess()
        {
            // Arrange
            var userId = 1L;
            var command = new DeleteUserCommand { UserId = userId };

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _userRepositoryMock.Verify(repo => repo.DeleteAsync(userId), Times.Once);
            response.Should().NotBeNull();
            response.Success.Should().BeTrue();
        }
    }
}