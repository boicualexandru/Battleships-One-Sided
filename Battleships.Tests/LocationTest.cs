using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Battleships.Tests
{
    public class LocationTest
    {
        [Theory]
        [InlineData(new int[] { 1, 3 })]
        [InlineData(new int[] { 1, 6 })]
        [InlineData(new int[] { 6, 3 })]
        [InlineData(new int[] { 0, 3 })]
        [InlineData(new int[] { 0, 0 })]
        [InlineData(new int[] { -3, -6 })]
        public void CompareTo_WithDifferentLocation_ShouldReturnNegative(int[] location2Coordinates)
        {
            // Arrange
            var location1 = new Location
            {
                X = 3,
                Y = 6
            };

            var location2 = new Location
            {
                X = location2Coordinates[0],
                Y = location2Coordinates[1]
            };

            // Act
            var compareResult = location1.CompareTo(location2);

            // Assert
            Assert.True(compareResult < 0);
        }

        [Fact]
        public void CompareTo_WithSameLocation_ShouldReturnZero()
        {
            // Arrange
            var location1 = new Location
            {
                X = 3,
                Y = 6
            };

            var location2 = new Location
            {
                X = 3,
                Y = 6
            };

            // Act
            var compareResult = location1.CompareTo(location2);

            // Assert
            Assert.True(compareResult == 0);
        }
    }
}
