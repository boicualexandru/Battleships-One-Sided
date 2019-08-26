using Battleships.Enums;
using Battleships.Models;
using Battleships.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    public class Ship : IShip
    {
        public List<ShipCell> Body { get; } = new List<ShipCell>();

        public Axis Axis { get; }

        public bool IsSunk
        {
            get
            {
                return Body.All(cell => cell.IsHit);
            }
        }

        public Location Head
        {
            get
            {
                return Body.First().Location;
            }
        }

        public Location Tail
        {
            get
            {
                return Body.Last().Location;
            }
        }

        public Ship(Location head, Axis axis, ShipType shipType)
        {
            var length = ShipUtils.GetShipLength(shipType);

            for (int index = 0; index < length; index++)
            {
                Body.Add(new ShipCell
                {
                    Location = new Location
                    {
                        X = head.X + (axis == Axis.Vertical ? 0 : index),
                        Y = head.Y + (axis == Axis.Horizontal ? 0 : index)
                    }
                });

                Axis = axis;
            }

        }

        public bool TryHit(Location location)
        {
            var index = GetIndex(location);

            if (index < 0)
            {
                return false;
            }

            Body.ElementAt(index).IsHit = true;
            return true;
        }

        public bool Intersects(IShip ship)
        {
            if (ShipUtils.AreBothAxisHorizontal(ship.Axis, Axis))
            {
                return IntersectsHorizontally(ship);
            }

            if (ShipUtils.AreBothAxisVertical(ship.Axis, Axis))
            {
                return IntersectsVertically(ship);
            }

            return ship.Body.Any(cell => GetIndex(cell.Location) == 0);
        }

        private bool IntersectsHorizontally(IShip ship)
        {
            if (!ShipUtils.AreOnTheSameLine(ship.Head, Head))
            {
                return false;
            }

            if (!ShipUtils.AreRangesIntersecting(ship.Head.X, ship.Tail.X, Head.X, Tail.X))
            {
                return false;
            }

            return true;
        }

        private bool IntersectsVertically(IShip ship)
        {
            if (!ShipUtils.AreOnTheSameColumn(ship.Head, Head))
            {
                return false;
            }

            if (!ShipUtils.AreRangesIntersecting(ship.Head.Y, ship.Tail.Y, Head.Y, Tail.X))
            {
                return false;
            }

            return true;
        }

        private int GetIndex(Location location)
        {
            return Axis == Axis.Horizontal ?
                GetIndexHorizontally(location) :
                GetIndexVertically(location);
        }

        private int GetIndexHorizontally(Location location)
        {
            if (location.Y != Head.Y)
            {
                return -1;
            }

            if (location.X < Head.X || location.X > Tail.X)
            {
                return -1;
            }

            return location.X - Head.X;
        }

        private int GetIndexVertically(Location location)
        {
            if (location.X != Head.X)
            {
                return -1;
            }

            if (location.Y < Head.Y || location.Y > Tail.Y)
            {
                return -1;
            }

            return location.Y - Head.Y;
        }
    }
}
