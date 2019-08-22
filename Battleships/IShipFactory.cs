namespace Battleships
{
    public interface IShipFactory
    {
        IShip GetRandomShip(int mapWidth, int mapHeight);
    }
}
