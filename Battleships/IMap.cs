using Battleships.Models;

namespace Battleships
{
    public interface IMap
    {
        int Width { get; }

        int Height { get; }

        bool IsFinished { get; }

        void Load();

        bool TryHit(Location location);

        string ToString();
    }
}
