namespace Battleships
{
    public interface IUserInterface
    {
        string GetInput();

        void Display(string text);

        void Clear();
    }
}
