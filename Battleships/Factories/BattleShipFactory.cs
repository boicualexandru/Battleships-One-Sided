using Battleships.Enums;

namespace Battleships.Factories
{
    public class BattleShipFactory : BaseShipFactory, IBattleShipFactory
    {
        public override IShip GetRandomShip(int mapWidth, int mapHeight)
        {
            return base.GetRandomShip(mapWidth, mapHeight, ShipType.BattleShip);
        }
    }
}
