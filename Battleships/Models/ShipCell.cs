namespace Battleships.Models
{
    public class ShipCell
    {
        public Location Location { get; set; }

        public bool IsHit { get; set; } = false;
    }
}
