using Domain.Entities;

namespace UnitTests.Domain.Entities
{
    public class UserEntityTests
    {
        [Fact]
        public void UserEntity_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var userEntity = new UserEntity(null, null, null, null, null);

            // Assert
            Assert.Null(userEntity.Id);
            Assert.Null(userEntity.DateOfBirth);
            Assert.Null(userEntity.TypeId);
            Assert.Null(userEntity.Type);
        }

        [Fact]
        public void UserEntity_ShouldSetPropertiesCorrectly_WithConstructor()
        {
            // Arrange
            long expectedId = 1;
            string expectedName = "John Doe";
            string expectedRegistration = "123456";
            var expectedDateOfBirth = new DateOnly(1990, 1, 1);
            string expectedEmailAddress = "johndoe@example.com";
            long expectedTypeId = 2;

            // Act
            var userEntity = new UserEntity(expectedName, expectedRegistration, expectedDateOfBirth, expectedEmailAddress, expectedTypeId, expectedId);

            // Assert
            Assert.Equal(expectedId, userEntity.Id);
            Assert.Equal(expectedName, userEntity.Name);
            Assert.Equal(expectedRegistration, userEntity.Registration);
            Assert.Equal(expectedDateOfBirth, userEntity.DateOfBirth);
            Assert.Equal(expectedEmailAddress, userEntity.EmailAddress);
            Assert.Equal(expectedTypeId, userEntity.TypeId);
            Assert.Null(userEntity.Type);
        }

        [Fact]
        public void UserEntity_ShouldSetIdUsingMethod()
        {
            // Arrange
            var userEntity = new UserEntity(null, null, null, null, null);
            long expectedId = 1;

            // Act
            userEntity.SetId(expectedId);

            // Assert
            Assert.Equal(expectedId, userEntity.Id);
        }

        [Fact]
        public void UserEntity_ShouldInitialize_WithMinimalConstructor()
        {
            // Arrange
            string expectedName = "Jane Doe";
            string expectedRegistration = "654321";
            var expectedDateOfBirth = new DateOnly(1995, 5, 15);
            string expectedEmailAddress = "janedoe@example.com";
            long expectedTypeId = 3;

            // Act
            var userEntity = new UserEntity(expectedName, expectedRegistration, expectedDateOfBirth, expectedEmailAddress, expectedTypeId);

            // Assert
            Assert.Null(userEntity.Id);
            Assert.Equal(expectedName, userEntity.Name);
            Assert.Equal(expectedRegistration, userEntity.Registration);
            Assert.Equal(expectedDateOfBirth, userEntity.DateOfBirth);
            Assert.Equal(expectedEmailAddress, userEntity.EmailAddress);
            Assert.Equal(expectedTypeId, userEntity.TypeId);
            Assert.Null(userEntity.Type);
        }
    }
}