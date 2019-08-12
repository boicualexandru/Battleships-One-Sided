namespace Battleships
{
    public class BattleShipFactory : BaseShipFactory
    {
        public override Ship GetRandomShip(int mapWidth, int mapHeight)
        {
            var axis = (Axis)_axisValues.GetValue(_random.Next(_axisValues.Length));
            var headLocation = GetRandomShipHead(mapWidth, mapHeight, axis, Constants.BattleshipLength);
            var battleship = new BattleShip(headLocation, axis);

            return battleship;
        }
    }
}
