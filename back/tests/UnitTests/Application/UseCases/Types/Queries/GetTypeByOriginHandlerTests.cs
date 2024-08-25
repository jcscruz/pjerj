using Application.DTOs;
using Application.UseCases.Types.Queries.GetTypeByOrigin;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Types.Queries
{
    public class GetTypeByOriginHandlerTests
    {
        private readonly Mock<ITypeRepository> _typeRepositoryMock;
        private readonly GetTypeByOriginHandler _handler;

        public GetTypeByOriginHandlerTests()
        {
            _typeRepositoryMock = new Mock<ITypeRepository>();
            _handler = new GetTypeByOriginHandler(_typeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnTypeByOrigin()
        {
            // Arrange
            var origin = "System";
            var typeEntity = new TypeEntity
            {
                Id = 1,
                Description = "Test Type",
                Origin = origin
            };
            var query = new GetTypeByOriginQuery(origin);

            _typeRepositoryMock.Setup(repo => repo.GetByOriginAsync(origin))
                .ReturnsAsync(typeEntity);

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            _typeRepositoryMock.Verify(repo => repo.GetByOriginAsync(origin), Times.Once);
            response.Should().NotBeNull();
            response.UserType.Should().NotBeNull();
            response.UserType.Should().BeEquivalentTo(new GetTypeDto(typeEntity.Id, typeEntity.Description, typeEntity.Origin));
        }

        [Fact]
        public async Task Handle_ShouldReturnNullIfTypeNotFound()
        {
            // Arrange
            var origin = "Unknown";
            var query = new GetTypeByOriginQuery(origin);

            _typeRepositoryMock.Setup(repo => repo.GetByOriginAsync(origin))
                .ReturnsAsync((TypeEntity?)null);

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            _typeRepositoryMock.Verify(repo => repo.GetByOriginAsync(origin), Times.Once);
            response.Should().NotBeNull();
            response.UserType.Should().BeNull();
        }
    }
}