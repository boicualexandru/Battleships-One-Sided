namespace Battleships
{
    public class BattleShip : Ship
    {
        public BattleShip(Location head, Axis axis) : base(head, axis, Constants.BattleshipLength)
        {
        }
    }
}
