using Application.UseCases.Types.Commands;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Types.Commands
{
    public class CreateTypeHandlerTests
    {
        private readonly Mock<ITypeRepository> _typeRepositoryMock;
        private readonly CreateTypeHandler _handler;

        public CreateTypeHandlerTests()
        {
            _typeRepositoryMock = new Mock<ITypeRepository>();
            _handler = new CreateTypeHandler(_typeRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateTypeAndReturnId()
        {
            // Arrange
            var command = new CreateTypeCommand("System", "Test Type");
            var typeEntity = new TypeEntity
            {
                Origin = command.Origin,
                Description = command.Description
            };
            var typeId = 1L;

            _typeRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<TypeEntity>()))
                .ReturnsAsync(typeId);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _typeRepositoryMock.Verify(repo => repo.AddAsync(It.Is<TypeEntity>(te =>
                te.Origin == command.Origin &&
                te.Description == command.Description)), Times.Once);

            response.Should().NotBeNull();
            response.TypeId.Should().Be(typeId);
        }
    }
}