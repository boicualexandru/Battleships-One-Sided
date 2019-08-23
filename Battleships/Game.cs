using Battleships.Models;
using System;

namespace Battleships
{
    public class Game : IGame
    {
        private readonly IMap _map;
        private readonly IUserInterface _userInterface;

        public Game(IMap map, IUserInterface userInterface)
        {
            _map = map;
            _userInterface = userInterface;
        }

        public void Start()
        {
            _map.Load();

            while (!_map.IsFinished)
            {
                Loop();
            }

            DrawMap();

            _userInterface.Display("\n\n\nCongratulations, you won!");
        }

        private void Loop()
        {
            try
            {
                DrawMap();
                var location = ReadCoordinates();

                _map.TryHit(location);
            }
            catch (InvalidOperationException ex)
            {
                _userInterface.Display("\n\n" + ex.Message);
                _userInterface.Display("\nPress Enter to repeat the last move...");
                _userInterface.GetInput();
            }
            catch (Exception ex)
            {
                _userInterface.Display("\n\nSomething went wrong.");
                _userInterface.Display("\nPress Enter key to repeat the last move...");
                _userInterface.GetInput();
            }
        }

        private void DrawMap()
        {
            _userInterface.Clear();
            _userInterface.Display(_map.ToString());
        }

        private Location ReadCoordinates()
        {
            var x = ReadX();
            var y = ReadY();

            return new Location
            {
                X = x,
                Y = y
            };
        }

        private int ReadX()
        {
            _userInterface.Display($"\n\n\nChose X (A-{(char)('A' + _map.Width - 1)}):");
            var xString = _userInterface.GetInput();
            xString = xString.Trim().ToLower();

            var x = xString[0] - 'a';

            while (x < 0 || x >= _map.Width)
            {
                _userInterface.Display("\nX coordinate is out of range. Please enter the value again.");
                xString = _userInterface.GetInput();
                xString = xString.Trim().ToLower();

                x = xString[0] - 'a';
            }

            return x;
        }

        private int ReadY()
        {
            _userInterface.Display($"\n\n\nChose Y (1-{_map.Height}):");
            var yString = _userInterface.GetInput();
            yString = yString.Trim().ToLower();

            var y = int.Parse(yString) - 1;

            while (y < 0 || y >= _map.Height)
            {
                _userInterface.Display("\nY coordinate is out of range. Please enter the value again.");
                yString = _userInterface.GetInput();
                yString = yString.Trim().ToLower();

                y = int.Parse(yString) - 1;
            }

            return y;
        }
    }
}
