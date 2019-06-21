using Application.InputProcessor.Models;
using Xunit;
using Application.Utilities;

namespace Application.UnitTests.Utilities
{
    public class DirectionFromBehaviorExtensionTests
    {
        [Theory]
        [InlineData(DirectionEnum.East, MoveBehaviorEnum.Left, DirectionEnum.North)]
        [InlineData(DirectionEnum.East, MoveBehaviorEnum.Right, DirectionEnum.South)]
        [InlineData(DirectionEnum.North, MoveBehaviorEnum.Left, DirectionEnum.West)]
        [InlineData(DirectionEnum.West, MoveBehaviorEnum.Right, DirectionEnum.North)]
        [InlineData(DirectionEnum.South, MoveBehaviorEnum.Left, DirectionEnum.East)]
        [InlineData(DirectionEnum.South, MoveBehaviorEnum.Move, DirectionEnum.South)]
        [InlineData(DirectionEnum.East, MoveBehaviorEnum.Move, DirectionEnum.East)]
        public void NextDirection_ShouldReturnCorrectDirection(DirectionEnum currentEnum, MoveBehaviorEnum moveBehavior, DirectionEnum expected)
        {
            //Arrange & Act
            var actualDirection = currentEnum.NextDirection(moveBehavior);
            //Assert
            Assert.Equal(expected, actualDirection);
        }
    }
}