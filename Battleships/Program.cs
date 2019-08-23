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
                .AddTransient<IUserInterface, UserInterface>()
                .AddTransient<IGame, Game>()
                .AddSingleton<MapConfiguration>(_ => {
                    return config.GetSection("MapConfiguration").Get<MapConfiguration>();
                })
                .BuildServiceProvider();

            var game = serviceProvider.GetService<IGame>();
            game.Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
