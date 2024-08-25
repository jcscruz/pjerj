using Application.DTOs;
using Application.UseCases.Users.Queries.GetAllUsers;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Users.Queries
{
    public class GetAllUsersHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly GetAllUsersHandler _handler;

        public GetAllUsersHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetAllUsersHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUsers_WhenUsersAreAvailable()
        {
            // Arrange
            var origin = "System";
            var users = new List<UserEntity>
            {
                new UserEntity("John Doe", "123456", new DateOnly(1990, 1, 1), "johndoe@example.com", 1),
                new UserEntity("Jane Doe", "654321", new DateOnly(1995, 5, 15), "janedoe@example.com", 2)
            };

            _userRepositoryMock.Setup(repo => repo.GetAllAsync(origin))
                .ReturnsAsync(users);

            var query = new GetAllUsersQuery(origin);

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Users.Should().HaveCount(users.Count);
            response.Users.Should().BeEquivalentTo(users.Select(user =>
                new GetUserDto(user.Id, user.Name, user.Registration, user.DateOfBirth, user.EmailAddress, user.Type?.Origin ?? string.Empty))
            );
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoUsersAreAvailable()
        {
            // Arrange
            var origin = "System";
            var users = new List<UserEntity>();

            _userRepositoryMock.Setup(repo => repo.GetAllAsync(origin))
                .ReturnsAsync(users);

            var query = new GetAllUsersQuery(origin);

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Users.Should().BeEmpty();
        }
    }
}