namespace Battleships
{
    public class DestroyerShipFactory : BaseShipFactory
    {
        public override Ship GetRandomShip(int mapWidth, int mapHeight)
        {
            var axis = (Axis)_axisValues.GetValue(_random.Next(_axisValues.Length));
            var headLocation = GetRandomShipHead(mapWidth, mapHeight, axis, Constants.DestroyerLength);
            var destroyer = new DestroyerShip(headLocation, axis);

            return destroyer;
        }
    }
}
