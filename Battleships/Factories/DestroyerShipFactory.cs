using Battleships.Enums;

namespace Battleships.Factories
{
    public class DestroyerShipFactory : BaseShipFactory, IDestroyerShipFactory
    {
        public override IShip GetRandomShip(int mapWidth, int mapHeight)
        {
            return base.GetRandomShip(mapWidth, mapHeight, ShipType.BattleShip);
        }
    }
}
