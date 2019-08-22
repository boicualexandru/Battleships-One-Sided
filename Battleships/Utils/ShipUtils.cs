using Battleships.Enums;
using Battleships.Models;
using System;

namespace Battleships.Utils
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

        public static bool AreBothAxisHorizontal(Axis axis1, Axis axis2)
        {
            return axis1 == Axis.Horizontal && axis2 == Axis.Horizontal;
        }

        public static bool AreBothAxisVertical(Axis axis1, Axis axis2)
        {
            return axis1 == Axis.Vertical && axis2 == Axis.Vertical;
        }

        public static bool AreOnTheSameLine(Location location1, Location location2)
        {
            return location1.Y == location2.Y;
        }

        public static bool AreOnTheSameColumn(Location location1, Location location2)
        {
            return location1.X == location2.X;
        }

        public static bool AreRangesIntersecting(int range1Start, int range1End, int range2Start, int range2End)
        {
            return !(range1Start > range2End || range1End < range2Start);
        }
    }
}
