using System;

namespace MarsRover
{
    public enum Orientation
    { // If you turn left, you will go to the previous
      // If you turn right, you will go to the next
        N,
        E,
        S,
        W
    }

    public enum RoverStatus
    {
        Healthy,
        OffPlateau,
        Collided
    }
    public class Rover
    {
        private int X;
        private int Y;
        public Orientation Orientation;
        public Coordinate Coordinate => new Coordinate { X = X, Y = Y };
        public RoverStatus Status { get; set; } = RoverStatus.Healthy;

        public Rover(int x, int y, string orientation)
        {
            X = x;
            Y = y;
            Enum.TryParse(orientation, out Orientation);
        }

        public void PerformManoeuvre(string command)
        {
            if (command == "M")
            {
                MoveManoeuvre();
            }
            else
            {
                RotateManoeuvre(command);
            }
        }

        private void RotateManoeuvre(string rotation) => Orientation = (Orientation, rotation) switch
        {
            (Orientation.N, "L") => Orientation.W,
            (Orientation.N, "R") => Orientation.E,
            (Orientation.S, "L") => Orientation.E,
            (Orientation.S, "R") => Orientation.W,
            (Orientation.E, "L") => Orientation.N,
            (Orientation.E, "R") => Orientation.S,
            (Orientation.W, "L") => Orientation.S,
            _ => Orientation.N
        };

        private void MoveManoeuvre()
        {
            (X, Y) = Orientation switch
            {
                Orientation.N => (X, Y + 1),
                Orientation.S => (X, Y - 1),
                Orientation.W => (X - 1, Y),
                _ => (X + 1, Y)
            };
        }
    }
 }
