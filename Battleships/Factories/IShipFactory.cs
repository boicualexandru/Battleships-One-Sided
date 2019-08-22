namespace Battleships.Factories
{
    public interface IShipFactory
    {
        IShip GetRandomShip(int mapWidth, int mapHeight);
    }
}
