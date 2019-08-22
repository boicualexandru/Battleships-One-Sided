using Battleships.Enums;
using Battleships.Models;
using System.Collections.Generic;

namespace Battleships
{
    public interface IShip
    {
        List<ShipCell> Body { get; }

        Axis Axis { get; }

        bool IsSunk { get; }

        Location Head { get; }

        Location Tail { get; }

        bool TryHit(Location location);

        bool Intersects(IShip ship);
    }
}
