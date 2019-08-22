using System;

namespace Battleships
{
    static class ShipUtils
    {
        public static int GetShipLength(ShipType shipType)
        {
            switch (shipType)
            {
                case ShipType.BattleShip:
                    return Constants.BattleshipLength;
                case ShipType.Destroyer:
                    return Constants.DestroyerLength;
            }

            throw new ArgumentException($"No length defined for ship type: {shipType.ToString()}.");
        }
    }
}
