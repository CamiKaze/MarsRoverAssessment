using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class RoverManager
    {
        private readonly Plateau Plateau;
        private List<Rover> Rovers;
        public List<Coordinate> FinalPositions;
        private List<string> InputManoeuvres;

        public RoverManager(Plateau plateau, List<string> inputPositions, List<string> inputManoeuvres)
        {
            Plateau = plateau;

            Rovers = inputPositions.Select(position =>
            {
                var x = position.Split(" ");
                return new Rover(Convert.ToInt32(x[0]), Convert.ToInt32(x[1]), x[2]);
            }).ToList();

            InputManoeuvres = inputManoeuvres;

            FinalPositions = new List<Coordinate>();
        }

        public void PerformRoverManoeuvres()
        {
            for (int i = 0; i < InputManoeuvres.Count; i++)
            {
                var commands = InputManoeuvres[i];
                var commandsArray = commands.ToCharArray();
                var rover = Rovers[i];

                foreach (char command in commandsArray)
                {
                    rover.PerformManoeuvre(command.ToString());
                    var currentCoordinate = rover.Coordinate;
                    var isValid = Plateau.IsValidCoordinate(currentCoordinate);

                    if (!isValid)
                    {
                        rover.Status = RoverStatus.OffPlateau;
                        break;
                    }

                    FinalPositions.Add(currentCoordinate);
                }
            }
        }

        public void PrintResults()
        {
            Rovers.ForEach(rover =>
            {
                Console.WriteLine($"Final Position: {rover.Coordinate} {rover.Orientation}");
            });
        }
    }
}
