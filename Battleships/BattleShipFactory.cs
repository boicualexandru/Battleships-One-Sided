namespace Battleships
{
    public class BattleShipFactory : BaseShipFactory
    {
        public override IShip GetRandomShip(int mapWidth, int mapHeight)
        {
            var axis = (Axis)_axisValues.GetValue(_random.Next(_axisValues.Length));
            var headLocation = GetRandomShipHead(mapWidth, mapHeight, axis, Constants.BattleshipLength);
            var battleship = new Ship(headLocation, axis, ShipType.BattleShip);

            return battleship;
        }
    }
}
