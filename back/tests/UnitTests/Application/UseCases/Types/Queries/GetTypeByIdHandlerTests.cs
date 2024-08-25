using Application.DTOs;
using Application.UseCases.Types.Queries.GetTypeById;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Types.Queries
{
    public class GetTypeByIdHandlerTests
    {
        private readonly Mock<ITypeRepository> _typeRepositoryMock;
        private readonly GetTypeByIdHandler _handler;

        public GetTypeByIdHandlerTests()
        {
            _typeRepositoryMock = new Mock<ITypeRepository>();
            _handler = new GetTypeByIdHandler(_typeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnTypeById()
        {
            // Arrange
            var typeId = 1L;
            var typeEntity = new TypeEntity
            {
                Id = typeId,
                Description = "Test Type",
                Origin = "System"
            };
            var query = new GetTypeByIdQuery(typeId);

            _typeRepositoryMock.Setup(repo => repo.GetByIdAsync(typeId))
                .ReturnsAsync(typeEntity);

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            _typeRepositoryMock.Verify(repo => repo.GetByIdAsync(typeId), Times.Once);
            response.Should().NotBeNull();
            response.UserType.Should().NotBeNull();
            response.UserType.Should().BeEquivalentTo(new GetTypeDto(typeEntity.Id, typeEntity.Description, typeEntity.Origin));
        }

        [Fact]
        public async Task Handle_ShouldReturnNullIfTypeNotFound()
        {
            // Arrange
            var typeId = 2L;
            var query = new GetTypeByIdQuery(typeId);

            _typeRepositoryMock.Setup(repo => repo.GetByIdAsync(typeId))
                .ReturnsAsync((TypeEntity?)null);

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            _typeRepositoryMock.Verify(repo => repo.GetByIdAsync(typeId), Times.Once);
            response.Should().NotBeNull();
            response.UserType.Should().BeNull();
        }
    }
}