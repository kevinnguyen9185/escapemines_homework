using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using Application.InputProcessor.Models;
using Application.SequenceProcessor;
using Application.SequenceProcessor.Models;
using Xunit;

namespace Application.UnitTests.SequenceProcessor
{
    public class SequenceMoveHandlerTests
    {
        [Theory]
        [InlineData(MoveBehaviorEnum.Move, DirectionEnum.North, 1, 1, DirectionEnum.North, 1, 0)]
        [InlineData(MoveBehaviorEnum.Move, DirectionEnum.North, 2, 0, DirectionEnum.North, 2, 0)]
        [InlineData(MoveBehaviorEnum.Move, DirectionEnum.South, 2, 4, DirectionEnum.South, 2, 4)]
        [InlineData(MoveBehaviorEnum.Move, DirectionEnum.South, 2, 3, DirectionEnum.South, 2, 4)]
        [InlineData(MoveBehaviorEnum.Move, DirectionEnum.East, 4, 1, DirectionEnum.East, 4, 1)]
        [InlineData(MoveBehaviorEnum.Move, DirectionEnum.East, 3, 1, DirectionEnum.East, 4, 1)]
        [InlineData(MoveBehaviorEnum.Move, DirectionEnum.West, 0, 1, DirectionEnum.West, 0, 1)]
        [InlineData(MoveBehaviorEnum.Move, DirectionEnum.West, 1, 1, DirectionEnum.West, 0, 1)]
        [InlineData(MoveBehaviorEnum.Left, DirectionEnum.North, 1, 1, DirectionEnum.West, 1, 1)]
        [InlineData(MoveBehaviorEnum.Right, DirectionEnum.North, 1, 1, DirectionEnum.East, 1, 1)]
        [InlineData(MoveBehaviorEnum.Left, DirectionEnum.West, 1, 1, DirectionEnum.South, 1, 1)]
        [InlineData(MoveBehaviorEnum.Right, DirectionEnum.West, 1, 1, DirectionEnum.North, 1, 1)]
        public void Move_ShouldReturnCorrectPosition(MoveBehaviorEnum behavior, DirectionEnum direction, int posX,
            int posY, DirectionEnum expectedDirection, int expPosX, int expPosY)
        {
            //Arrange
            var currentPos = new Point(posX, posY);
            var expectedPos = new Point(expPosX, expPosY);
            var gameSetting = new GameSetting
            {
                BoardSize = new BoardSize
                {
                    Width = 5,
                    Height = 4
                }
            };
            var sequenceMoveHandler = new SequenceMoveHandler(gameSetting);
            //Act
            var expectedResult = sequenceMoveHandler.Move(behavior, direction, currentPos);
            //Assert
            Assert.Equal(expectedPos, expectedResult.CurrentPosition);
            Assert.Equal(expectedDirection, expectedResult.Direction);
        }

        [Theory]
        [InlineData(3,3, ResultEnum.MineHit)]
        [InlineData(4,4, ResultEnum.Success)]
        public void Check_ShouldReturnCorrectStatus(int posX, int posY, ResultEnum expectedResult)
        {
            //Arrange
            var currentPos = new Point(posX, posY);
            var gameSetting = new GameSetting
            {
                ExitPoint = new Point(4, 4),
                MinePositions = new List<Point>
                {
                    new Point(1, 1),
                    new Point(3, 3)
                }
            };
            var sequenceMoveHandler = new SequenceMoveHandler(gameSetting);
            //Act
            var actualCheck =
                sequenceMoveHandler.Check(new Position() {Direction = DirectionEnum.East, CurrentPosition = currentPos},
                    false);
            //Assert
            Assert.Equal(expectedResult, actualCheck);
        }
    }
}