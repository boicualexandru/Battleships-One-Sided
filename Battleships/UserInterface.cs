using System;

namespace Battleships
{
    public class UserInterface : IUserInterface
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Display(string text)
        {
            Console.WriteLine(text);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
