namespace Battleships
{
    public interface IShipFactory
    {
        Ship GetRandomShip(int mapWidth, int mapHeight);
    }
}
