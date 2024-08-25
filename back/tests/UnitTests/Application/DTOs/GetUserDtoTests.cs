using Application.DTOs;

namespace UnitTests.Application.DTOs
{
    public class GetUserDtoTests
    {
        [Fact]
        public void GetUserDto_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var getUserDto = new GetUserDto(null);

            // Assert
            Assert.Null(getUserDto.Id);
            Assert.Equal(string.Empty, getUserDto.Name);
            Assert.Equal(string.Empty, getUserDto.Registration);
            Assert.Null(getUserDto.DateOfBirth);
            Assert.Equal(string.Empty, getUserDto.EmailAddress);
            Assert.Equal(string.Empty, getUserDto.Origin);
        }

        [Fact]
        public void GetUserDto_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            long expectedId = 1;
            string expectedName = "John Doe";
            string expectedRegistration = "123456";
            var expectedDateOfBirth = new DateOnly(1990, 1, 1);
            string expectedEmailAddress = "johndoe@example.com";
            string expectedOrigin = "System";

            // Act
            var getUserDto = new GetUserDto(expectedId, expectedName, expectedRegistration, expectedDateOfBirth, expectedEmailAddress, expectedOrigin);

            // Assert
            Assert.Equal(expectedId, getUserDto.Id);
            Assert.Equal(expectedName, getUserDto.Name);
            Assert.Equal(expectedRegistration, getUserDto.Registration);
            Assert.Equal(expectedDateOfBirth, getUserDto.DateOfBirth);
            Assert.Equal(expectedEmailAddress, getUserDto.EmailAddress);
            Assert.Equal(expectedOrigin, getUserDto.Origin);
        }

        [Fact]
        public void GetUserDto_ShouldHaveValueEquality()
        {
            // Arrange
            var dto1 = new GetUserDto(1, "John Doe", "123456", new DateOnly(1990, 1, 1), "johndoe@example.com", "System");
            var dto2 = new GetUserDto(1, "John Doe", "123456", new DateOnly(1990, 1, 1), "johndoe@example.com", "System");

            // Act & Assert
            Assert.Equal(dto1, dto2);
            Assert.True(dto1 == dto2);
            Assert.False(dto1 != dto2);
        }

        [Fact]
        public void GetUserDto_ShouldGenerateDifferentHashCodesForDifferentValues()
        {
            // Arrange
            var dto1 = new GetUserDto(1, "John Doe", "123456", new DateOnly(1990, 1, 1), "johndoe@example.com", "System");
            var dto2 = new GetUserDto(2, "Jane Doe", "654321", new DateOnly(1995, 5, 15), "janedoe@example.com", "External");

            // Act & Assert
            Assert.NotEqual(dto1.GetHashCode(), dto2.GetHashCode());
        }
    }
}