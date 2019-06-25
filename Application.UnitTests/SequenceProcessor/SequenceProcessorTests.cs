using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.XPath;
using Application.InputProcessor.Models;
using Application.SequenceProcessor;
using Application.SequenceProcessor.Models;
using Application.Utilities;
using Xunit;

namespace Application.UnitTests.SequenceProcessor
{
    public class SequenceProcessorTests
    {
        private GameSetting _gameSetting;
        public SequenceProcessorTests()
        {
            _gameSetting = new GameSetting
            {
                BoardSize = new BoardSize() {Width = 5, Height = 5},
                ExitPoint = new Point(4, 1),
                MinePositions = new List<Point>
                {
                    new Point(2, 1),
                    new Point(3, 3)
                },
                StartingPosition = new Position {CurrentPosition = new Point(0, 1), Direction = DirectionEnum.East}
            };
        }
        
        [Theory]
        [InlineData("R M M", ResultEnum.MineHit)]
        [InlineData("L L M L M M L M", ResultEnum.MineHit)]
        [InlineData("L L M L M M M L M M M", ResultEnum.MineHit)]
        [InlineData("L L M L M M M M L M", ResultEnum.Success)]
        [InlineData("M M M M", ResultEnum.Danger)]
        public void ProcessGameSequences_ShouldReturnCorrectResult(string sequence, ResultEnum expectedResult)
        {
            //Arrange
            var sequences = new List<MoveBehaviorEnum>();
            foreach (var step in sequence.Split(' '))
            {
                sequences.Add(step.ToMoveBehaviorEnum());
            }

            _gameSetting.Sequences = new List<List<MoveBehaviorEnum>> {sequences};

            var sequenceMoveHandler = new SequenceMoveHandler(_gameSetting);
            var sequenceProcessor =
                new Application.SequenceProcessor.SequenceProcessor(_gameSetting, sequenceMoveHandler);
            //Act
            var result = sequenceProcessor.ProcessGameSequences().ToList();
            //Assert
            Assert.Equal(expectedResult, result[0].Result);
        }

        [Fact]
        public void ProcessGameSequences_ShouldReturnExactNumberOfSequences()
        {
            //Arrange
            var sequence = "L L M L M M M L M M M";
            var sequences = new List<MoveBehaviorEnum>();
            foreach (var step in sequence.Split(' '))
            {
                sequences.Add(step.ToMoveBehaviorEnum());
            }
            _gameSetting.Sequences = new List<List<MoveBehaviorEnum>>{sequences, sequences};

            var sequenceMoveHandler = new SequenceMoveHandler(_gameSetting);
            var sequenceProcessor =
                new Application.SequenceProcessor.SequenceProcessor(_gameSetting, sequenceMoveHandler);
            //Act
            var result = sequenceProcessor.ProcessGameSequences().ToList();
            //Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(ResultEnum.MineHit, result[0].Result);
            Assert.Equal(ResultEnum.MineHit, result[1].Result);
        }
    }
}