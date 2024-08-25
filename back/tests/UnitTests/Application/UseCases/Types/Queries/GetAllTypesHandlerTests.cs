using Application.DTOs;
using Application.UseCases.Types.Queries.GetAllTypes;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Types.Queries
{
    public class GetAllTypesHandlerTests
    {
        private readonly Mock<ITypeRepository> _typeRepositoryMock;
        private readonly GetAllTypesHandler _handler;

        public GetAllTypesHandlerTests()
        {
            _typeRepositoryMock = new Mock<ITypeRepository>();
            _handler = new GetAllTypesHandler(_typeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnAllTypes()
        {
            // Arrange
            var types = new List<TypeEntity>
            {
                new TypeEntity { Id = 1, Description = "Type1", Origin = "Origin1" },
                new TypeEntity { Id = 2, Description = "Type2", Origin = "Origin2" }
            };
            var query = new GetAllTypesQuery();

            _typeRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(types);

            // Act
            var response = await _handler.Handle(query, CancellationToken.None);

            // Assert
            _typeRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            response.Should().NotBeNull();
            response.Items.Should().HaveCount(types.Count);
            response.Items.Should().BeEquivalentTo(types.Select(t => new GetTypeDto(t.Id, t.Description, t.Origin)));
        }
    }
}