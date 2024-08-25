using Domain.Entities;

namespace UnitTests.Domain.Entities
{
    public class TypeEntityTests
    {
        [Fact]
        public void TypeEntity_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var typeEntity = new TypeEntity();

            // Assert
            Assert.Null(typeEntity.Id);
            Assert.Equal(string.Empty, typeEntity.Description);
            Assert.Equal(string.Empty, typeEntity.Origin);
            Assert.Null(typeEntity.Users);
        }

        [Fact]
        public void TypeEntity_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            long expectedId = 1;
            string expectedDescription = "Admin";
            string expectedOrigin = "System";
            var expectedUsers = new List<UserEntity>();

            // Act
            var typeEntity = new TypeEntity
            {
                Id = expectedId,
                Description = expectedDescription,
                Origin = expectedOrigin,
                Users = expectedUsers
            };

            // Assert
            Assert.Equal(expectedId, typeEntity.Id);
            Assert.Equal(expectedDescription, typeEntity.Description);
            Assert.Equal(expectedOrigin, typeEntity.Origin);
            Assert.Equal(expectedUsers, typeEntity.Users);
        }

        [Fact]
        public void TypeEntity_ShouldHandleNullUsers()
        {
            // Arrange & Act
            var typeEntity = new TypeEntity
            {
                Users = null
            };

            // Assert
            Assert.Null(typeEntity.Users);
        }
    }
}