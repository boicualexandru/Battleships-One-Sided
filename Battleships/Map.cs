﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    public class Map
    {
        public bool IsFinished
        {
            get
            {
                return Ships.All(ship => ship.IsSunk);
            }
        }

        private List<Location> Hits { get; } = new List<Location>();

        private List<Location> Misses { get; } = new List<Location>();

        private List<Ship> Ships { get; } = new List<Ship>();

        private readonly IShipFactory _battleShipFactory;

        private readonly IShipFactory _destroyerShipFactory;

        private readonly MapConfiguration _mapConfiguration;

        public Map(IShipFactory battleShipFactory, IShipFactory destroyerShipFactory, MapConfiguration mapConfiguration)
        {
            _battleShipFactory = battleShipFactory;
            _destroyerShipFactory = destroyerShipFactory;
            _mapConfiguration = mapConfiguration;
        }

        public void Load()
        {
            LoadBattleships();
            LoadDestroyers();
        }

        public bool TryHit(Location location)
        {
            var isHit = Ships.Any(ship => ship.TryHit(location));

            if (isHit)
            {
                Hits.Add(location);
            }
            else
            {
                Misses.Add(location);
            }

            return isHit;
        }

        public override string ToString()
        {
            var result = String.Empty;
            result += Enumerable.Range('A', _mapConfiguration.Width).Aggregate("  ", (accumulator, item) => accumulator + (char)item);

            for (int i = 0; i < _mapConfiguration.Height; i++)
            {
                var rowNumber = i + 1;
                var row = "\n" + rowNumber.ToString() + (rowNumber < 10 ? " " : String.Empty);

                for(int j = 0; j < _mapConfiguration.Width; j++)
                {
                    var cellStatus = GetMapCellStatus(j, i);
                    row += GetCellStatusSymbol(cellStatus);
                }

                result += row;
            }

            return result;
        }

        private MapCellStatus GetMapCellStatus(int x, int y)
        {
            if(Hits.Any(location => location.X == x && location.Y == y))
            {
                return MapCellStatus.Hit;
            }

            if (Misses.Any(location => location.X == x && location.Y == y))
            {
                return MapCellStatus.Miss;
            }

            return MapCellStatus.Default;
        }

        private char GetCellStatusSymbol(MapCellStatus cellStatus)
        {
            switch (cellStatus)
            {
                case MapCellStatus.Hit:
                    return 'X';
                case MapCellStatus.Miss:
                    return 'O';
                case MapCellStatus.Default:
                default:
                    return ' ';
            }
        }

        private void LoadBattleships()
        {
            var generatedShips = 0;

            while(generatedShips < _mapConfiguration.BattleshipsCount)
            {
                var battleship = _battleShipFactory.GetRandomShip(_mapConfiguration.Width, _mapConfiguration.Height);

                if (!Ships.Any(ship => ship.Intersects(battleship)))
                {
                    Ships.Add(battleship);
                    generatedShips++;
                }
            }
        }

        private void LoadDestroyers()
        {
            var axisValues = Enum.GetValues(typeof(Axis));

            var generatedShips = 0;

            while (generatedShips < _mapConfiguration.DestroyersCount)
            {
                var destroyer = _destroyerShipFactory.GetRandomShip(_mapConfiguration.Width, _mapConfiguration.Height);

                if (!Ships.Any(ship => ship.Intersects(destroyer)))
                {
                    Ships.Add(destroyer);
                    generatedShips++;
                }
            }
        }
    }
}