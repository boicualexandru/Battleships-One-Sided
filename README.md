# Battleships-One-Sided
A simple console game of one sided battleships

# Play Guide
The map is a Grid of 10X10 cells.

3 Ships (1 battleship and 2 destroyers) will be randomly placed on the map.

Battleships have a length of 5 cells.
Destroyers have a length of 4 cells.

The goal is to sink all the ships on map by revealing and destroying every body part of them.
To reveal a cell on the map, you will have to guess its X and Y coordinates.
If a ship body is within the pointed location, the cell will be marked with an "X", otherwise, a "O" will mark the miss.

# Running the game
Run the executable file at path `\Battleships-One-Sided\Battleships\bin\Release\netcoreapp2.1\win10-x64\Battleships.exe`. Then follow the instructions on the screen.

# Regenerate the game file
To regenerate an .exe file, run the following command: `dotnet publish -c Release -r win10-x64`.