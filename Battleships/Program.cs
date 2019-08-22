using Battleships.Factories;
using Battleships.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();


            var serviceProvider = new ServiceCollection()
                .AddTransient<IBattleShipFactory, BattleShipFactory>()
                .AddTransient<IDestroyerShipFactory, DestroyerShipFactory>()
                .AddTransient<IMap, Map>()
                .AddSingleton<MapConfiguration>(_ => {
                    return config.GetSection("MapConfiguration").Get<MapConfiguration>();
                })
                .BuildServiceProvider();

            var map = serviceProvider.GetService<IMap>();
            map.Load();

            while (!map.IsFinished)
            {
                try
                {
                    Console.Clear();
                    Console.Write(map.ToString());

                    var x = ReadX(map.Width);
                    var y = ReadY(map.Height);

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

        private static int ReadX(int mapWidth)
        {
            Console.WriteLine($"\n\nChose X (A-{(char)('A' + mapWidth - 1)}):");
            var xString = Console.ReadLine();
            xString = xString.Trim().ToLower();

            var x = xString[0] - 'a';

            while (x < 0 || x >= mapWidth)
            {
                Console.WriteLine("X coordinate is out of range. Please enter the value again.");
                xString = Console.ReadLine();
                xString = xString.Trim().ToLower();

                x = xString[0] - 'a';
            }

            return x;
        }

        private static int ReadY(int mapHeight)
        {
            Console.WriteLine($"\n\nChose Y (1-{mapHeight}):");
            var yString = Console.ReadLine();
            yString = yString.Trim().ToLower();

            var y = int.Parse(yString) - 1;

            while (y < 0 || y >= mapHeight)
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
