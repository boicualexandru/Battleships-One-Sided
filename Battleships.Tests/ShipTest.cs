using Battleships.Enums;
using Battleships.Models;
using Xunit;

namespace Battleships.Tests
{
    public class ShipTest
    {
        [Theory]
        [InlineData(Axis.Horizontal)]
        [InlineData(Axis.Vertical)]
        public void Axis_WithInitialProvidedAxis_ShouldReturnTheInitialProvidedAxis(Axis axis)
        {
            // Arrange
            var head = new Location
            {
                X = 3,
                Y = 6
            };

            var ship = new Ship(head, axis, ShipType.BattleShip);

            // Act & Assert
            Assert.Equal(axis, ship.Axis);
        }

        [Fact]
        public void IsSunk_WithAllTheBodyHit_ShouldReturnTrue()
        {
            // Arrange
            var head = new Location
            {
                X = 3,
                Y = 6
            };

            var ship = new Ship(head, Axis.Horizontal, ShipType.BattleShip);

            foreach(var bodyCell in ship.Body)
            {
                ship.TryHit(bodyCell.Location);
            }

            // Act & Assert
            Assert.True(ship.IsSunk);
        }
    }
}
