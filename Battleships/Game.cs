using Battleships.Models;
using System;

namespace Battleships
{
    public class Game : IGame
    {
        private readonly IMap _map;

        public Game(IMap map)
        {
            _map = map;
        }

        public void Start()
        {
            _map.Load();

            while (!_map.IsFinished)
            {
                Loop();
            }

            DrawMap();

            Console.WriteLine("\n\nCongratulations, you won!");
        }

        private void Loop()
        {
            try
            {
                DrawMap();
                var location = ReadCoordinates();

                _map.TryHit(location);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.WriteLine("Press any key to repeat the last move...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nSomething went wrong.");
                Console.WriteLine("Press any key to repeat the last move...");
                Console.ReadKey();
            }
        }

        private void DrawMap()
        {
            Console.Clear();
            Console.Write(_map.ToString());
        }

        private Location ReadCoordinates()
        {
            var x = ReadX();
            var y = ReadY();

            return new Location
            {
                X = x,
                Y = y
            };
        }

        private int ReadX()
        {
            Console.WriteLine($"\n\nChose X (A-{(char)('A' + _map.Width - 1)}):");
            var xString = Console.ReadLine();
            xString = xString.Trim().ToLower();

            var x = xString[0] - 'a';

            while (x < 0 || x >= _map.Width)
            {
                Console.WriteLine("X coordinate is out of range. Please enter the value again.");
                xString = Console.ReadLine();
                xString = xString.Trim().ToLower();

                x = xString[0] - 'a';
            }

            return x;
        }

        private int ReadY()
        {
            Console.WriteLine($"\n\nChose Y (1-{_map.Height}):");
            var yString = Console.ReadLine();
            yString = yString.Trim().ToLower();

            var y = int.Parse(yString) - 1;

            while (y < 0 || y >= _map.Height)
            {
                Console.WriteLine("Y coordinate is out of range. Please enter the value again.");
                yString = Console.ReadLine();
                yString = yString.Trim().ToLower();

                y = int.Parse(yString) - 1;
            }

            return y;
        }
    }
}
