using Application.UseCases.Users.Queries.GetUserById;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Users.Queries
{
    public class GetUserByIdHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly GetUserByIdHandler _handler;

        public GetUserByIdHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetUserByIdHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = 1L;
            var user = new UserEntity("John Doe", "123456", new DateOnly(1990, 1, 1), "johndoe@example.com", 1)
            {
                Id = userId
            };

            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync(user);

            var query = new GetUserByIdQuery { UserID = userId };

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.User.Should().NotBeNull();
            response.User.Id.Should().Be(userId);
            response.User.Name.Should().Be(user.Name);
            response.User.Registration.Should().Be(user.Registration);
            response.User.DateOfBirth.Should().Be(user.DateOfBirth);
            response.User.EmailAddress.Should().Be(user.EmailAddress);
            response.User.Origin.Should().Be(user.Type?.Origin ?? string.Empty);
        }

        [Fact]
        public async Task Handle_ShouldReturnNullUser_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1L;

            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync((UserEntity?)null);

            var query = new GetUserByIdQuery { UserID = userId };

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.User.Should().BeNull();
        }
    }
}