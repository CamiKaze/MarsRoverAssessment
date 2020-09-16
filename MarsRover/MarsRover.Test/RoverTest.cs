using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
        [Fact]
        public void SetRoverCoordinate()
        {
            // Arrange
            Plateau plateau = new Plateau(0, 0, 5, 5);
            var coordinate = new Coordinate
            {
                X = 1,
                Y = 2
            };

            // Act
            var positionX = coordinate.X;
            var positionY = coordinate.Y;

            // Assert
            Assert.True((positionX >= plateau.LowerBoundX) && (positionX <= plateau.UpperBoundX));
            Assert.True((positionY >= plateau.LowerBoundY) && (positionY <= plateau.UpperBoundY));
        }

        [Fact]
        public void PlaceRover()
        {
            // Arrange
            Plateau plateau = new Plateau(0, 0, 5, 5);
            Rover rover = new Rover(1, 2, "N");

            // Act
            rover.PerformManoeuvre("LMLMLMLMM");
            
            // Assert
            Assert.True((rover.Coordinate.X < plateau.UpperBoundX && rover.Coordinate.Y < plateau.UpperBoundY));
            Assert.Equal("1", rover.Coordinate.X.ToString());
            //Assert.Equal("3", rover.Coordinate.X.ToString());

        }
    }
}
