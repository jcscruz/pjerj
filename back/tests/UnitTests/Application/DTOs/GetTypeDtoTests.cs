using Application.DTOs;

namespace UnitTests.Application.DTOs
{
    public class GetTypeDtoTests
    {
        [Fact]
        public void GetTypeDto_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var getTypeDto = new GetTypeDto(null);

            // Assert
            Assert.Null(getTypeDto.Id);
            Assert.Equal(string.Empty, getTypeDto.Description);
            Assert.Equal(string.Empty, getTypeDto.Origin);
        }

        [Fact]
        public void GetTypeDto_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            long expectedId = 1;
            string expectedDescription = "Admin";
            string expectedOrigin = "System";

            // Act
            var getTypeDto = new GetTypeDto(expectedId, expectedDescription, expectedOrigin);

            // Assert
            Assert.Equal(expectedId, getTypeDto.Id);
            Assert.Equal(expectedDescription, getTypeDto.Description);
            Assert.Equal(expectedOrigin, getTypeDto.Origin);
        }

        [Fact]
        public void GetTypeDto_ShouldHaveValueEquality()
        {
            // Arrange
            var dto1 = new GetTypeDto(1, "Admin", "System");
            var dto2 = new GetTypeDto(1, "Admin", "System");

            // Act & Assert
            Assert.Equal(dto1, dto2);
            Assert.True(dto1 == dto2);
            Assert.False(dto1 != dto2);
        }

        [Fact]
        public void GetTypeDto_ShouldGenerateDifferentHashCodesForDifferentValues()
        {
            // Arrange
            var dto1 = new GetTypeDto(1, "Admin", "System");
            var dto2 = new GetTypeDto(2, "User", "External");

            // Act & Assert
            Assert.NotEqual(dto1.GetHashCode(), dto2.GetHashCode());
        }
    }
}