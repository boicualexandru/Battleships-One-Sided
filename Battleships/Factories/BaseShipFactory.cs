using Battleships.Enums;
using Battleships.Models;
using System;

namespace Battleships.Factories
{
    public abstract class BaseShipFactory : IShipFactory
    {
        private readonly Random _random = new Random();

        private Array _axisValues = Enum.GetValues(typeof(Axis));

        public abstract IShip GetRandomShip(int mapWidth, int mapHeight);

        protected IShip GetRandomShip(int mapWidth, int mapHeight, ShipType shipType)
        {
            var axis = GetRandomShipAxis();
            var headLocation = GetRandomShipHead(mapWidth, mapHeight, axis, Constants.BattleshipLength);

            var battleship = new Ship(headLocation, axis, shipType);

            return battleship;
        }

        private Location GetRandomShipHead(int mapWidth, int mapHeight, Axis axis, int length)
        {
            var headAvailableWidth = axis == Axis.Horizontal ?
                    mapWidth - length + 1 :
                    mapWidth;

            var headAvailableHeight = axis == Axis.Vertical ?
                mapHeight - length + 1 :
                mapHeight;

            return new Location
            {
                X = _random.Next(0, headAvailableWidth - 1),
                Y = _random.Next(0, headAvailableHeight - 1)
            };
        }

        private Axis GetRandomShipAxis()
        {
            return (Axis)_axisValues.GetValue(_random.Next(_axisValues.Length));
        }
    }
}
