using System;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var battleShipFactory = new BattleShipFactory();
            var destroyerShipFactory = new DestroyerShipFactory();

            // TODO: Move to configs file
            var mapConfiguration = new MapConfiguration
            {
                Width = 10,
                Height = 10,
                BattleshipsCount = 1,
                DestroyersCount = 2
            };

            var map = new Map(battleShipFactory, destroyerShipFactory, mapConfiguration);
            map.Load();

            while (!map.IsFinished)
            {
                try
                {
                    Console.Clear();
                    Console.Write(map.ToString());

                    var x = ReadX(mapConfiguration);
                    var y = ReadY(mapConfiguration);

                    map.TryHit(new Location
                    {
                        X = x,
                        Y = y
                    });
                }
                catch(InvalidOperationException ex)
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

            Console.Clear();
            Console.Write(map.ToString());

            Console.WriteLine("\n\nCongratulations, you won!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static int ReadX(MapConfiguration mapConfiguration)
        {
            Console.WriteLine($"\n\nChose X (A-{(char)('A' + mapConfiguration.Width - 1)}):");
            var xString = Console.ReadLine();
            xString = xString.Trim().ToLower();

            var x = xString[0] - 'a';

            while (x < 0 || x >= mapConfiguration.Width)
            {
                Console.WriteLine("X coordinate is out of range. Please enter the value again.");
                xString = Console.ReadLine();
                xString = xString.Trim().ToLower();

                x = xString[0] - 'a';
            }

            return x;
        }

        private static int ReadY(MapConfiguration mapConfiguration)
        {
            Console.WriteLine($"\n\nChose Y (1-{mapConfiguration.Height}):");
            var yString = Console.ReadLine();
            yString = yString.Trim().ToLower();

            var y = int.Parse(yString) - 1;

            while (y < 0 || y >= mapConfiguration.Height)
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
