namespace Battleships
{
    public class DestroyerShipFactory : BaseShipFactory
    {
        public override IShip GetRandomShip(int mapWidth, int mapHeight)
        {
            var axis = (Axis)_axisValues.GetValue(_random.Next(_axisValues.Length));
            var headLocation = GetRandomShipHead(mapWidth, mapHeight, axis, Constants.DestroyerLength);
            var destroyer = new Ship(headLocation, axis, ShipType.Destroyer);

            return destroyer;
        }
    }
}
