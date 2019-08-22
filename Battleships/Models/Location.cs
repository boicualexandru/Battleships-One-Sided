using System;

namespace Battleships.Models
{
    public class Location : IComparable<Location>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int CompareTo(Location location)
        {
            return location.X == X && location.Y == Y ? 0 : -1;
        }
    }
}
