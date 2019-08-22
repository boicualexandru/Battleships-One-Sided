﻿using System.Collections.Generic;
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
            if(ship.Axis == Axis.Horizontal && Axis == Axis.Horizontal)
            {
                if(ship.Head.Y != Head.Y)
                {
                    return false;
                }

                if(ship.Head.X > Tail.X || ship.Tail.X < Head.X)
                {
                    return false;
                }

                return true;
            }


            if (ship.Axis == Axis.Vertical && Axis == Axis.Vertical)
            {
                if (ship.Head.X != Head.X)
                {
                    return false;
                }

                if (ship.Head.Y > Tail.Y || ship.Tail.Y < Head.Y)
                {
                    return false;
                }

                return true;
            }

            return ship.Body.Any(cell => GetIndex(cell.Location) == 0);
        }

        private int GetIndex(Location location)
        {
            if (Axis == Axis.Horizontal)
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
            else
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
}
