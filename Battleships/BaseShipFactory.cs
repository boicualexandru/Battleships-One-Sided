using System;

namespace Battleships
{
    public abstract class BaseShipFactory : IShipFactory
    {
        protected readonly Random _random = new Random();

        protected Array _axisValues = Enum.GetValues(typeof(Axis));

        public abstract IShip GetRandomShip(int mapWidth, int mapHeight);

        protected Location GetRandomShipHead(int mapWidth, int mapHeight, Axis axis, int length)
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
    }
}
