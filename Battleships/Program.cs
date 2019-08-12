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
                Console.Clear();
                Console.Write(map.ToString());

                Console.WriteLine($"\n\nChose X (A-{'A' + mapConfiguration.Width - 1}):");
                var xString = Console.ReadLine();
                xString = xString.Trim().ToLower();

                var x = xString[0] - 'a';

                Console.WriteLine($"\n\nChose Y (1-{mapConfiguration.Height}):");
                var yString = Console.ReadLine();
                yString = yString.Trim().ToLower();

                var y = int.Parse(yString) - 1;

                map.TryHit(new Location
                {
                    X = x,
                    Y = y
                });
            }

            Console.Clear();
            Console.Write(map.ToString());

            Console.WriteLine("\n\nCongratulations, you won!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
