using Xunit;

namespace MarsRover.Test
{
    public class PlateauTest
    {
        [Fact]
        public void CreatePlateau()
        {
            // Arrange
            Plateau plateau = new Plateau(0, 0, 5, 5);

            // Act
            var lowerBoundX = plateau.LowerBoundX;
            var lowerBoundY = plateau.LowerBoundY;
            var upperBoundX = plateau.UpperBoundX;
            var upperBoundY = plateau.UpperBoundY;

            // Assert
            Assert.Equal(0, plateau.LowerBoundX);
            Assert.Equal(0, plateau.LowerBoundY);
            Assert.Equal(5, plateau.UpperBoundX);
            Assert.Equal(5, plateau.UpperBoundY);

            Assert.True((lowerBoundX <= 5 && lowerBoundY <= 5));
            Assert.True((upperBoundX >= 0 && upperBoundY >= 0));
        }
    }
}
