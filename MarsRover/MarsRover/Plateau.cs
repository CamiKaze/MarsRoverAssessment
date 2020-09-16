using System;

namespace MarsRover
{
    public class Plateau
    {
        public readonly int LowerBoundX;
        public readonly int LowerBoundY;
        public readonly int UpperBoundX;
        public readonly int UpperBoundY;

        public Plateau(int x, int y)
        {
            UpperBoundX = x;
            UpperBoundY = y;
            LowerBoundX = 0;
            LowerBoundY = 0;
        }

        public Plateau(int lowerX, int lowerY, int upperX, int upperY) : this(upperX, upperY)
        {
            if ((lowerX >= upperX) || (lowerY >= upperY))
            {
                throw new ArgumentException("Lower bound values should be less than upper bound values");
            }

            LowerBoundX = lowerX;
            LowerBoundY = lowerY;
        }

        public bool IsValidCoordinate(Coordinate coordinate)
        {
            var isValidX = (coordinate.X >= LowerBoundX) && (coordinate.X <= UpperBoundX);
            var isValidY = (coordinate.Y >= LowerBoundY) && (coordinate.Y <= UpperBoundY);

            return isValidX && isValidY;
        }
    }
}
