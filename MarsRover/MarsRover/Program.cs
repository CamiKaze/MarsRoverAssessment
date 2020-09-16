using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var plateau = initializePlateau();
            var roverManager = initialiaseRoverManager(plateau);
            roverManager.PerformRoverManoeuvres();
            roverManager.PrintResults();
        }

        private static Plateau initializePlateau()
        {
            Console.WriteLine("Size of Map: X * Y\nEnter a value for X and Y to create a map");

            var plateauInput = Console.ReadLine();

            var plateauSize = plateauInput.Split(" ").Select(x => Convert.ToInt32(x)).ToArray();

            return plateauSize.Length switch
            {
                2 => new Plateau(plateauSize[0], plateauSize[1]),
                4 => new Plateau(plateauSize[0], plateauSize[1], plateauSize[2], plateauSize[3]),
                _ => throw new ArgumentException($"does not represent valid plateau: {plateauInput}")
            };
        }

        private static RoverManager initialiaseRoverManager(Plateau plateau)
        {
            Console.WriteLine("Input position and manoeuvres");
            var inputPositions = new List<string>();
            var inputManoeuvres = new List<string>();
            int lineNumber = 0;

            while (true)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                if (lineNumber % 2 == 0)
                    inputPositions.Add(line);
                else
                    inputManoeuvres.Add(line);

                lineNumber++;
            }

            return new RoverManager(plateau, inputPositions, inputManoeuvres);
        }
    }
}
