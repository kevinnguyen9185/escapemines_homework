using System.IO;
using System.Linq;
using Application.InputProcessor;
using Application.InputProcessor.Models;
using Xunit;

namespace Application.UnitTests.InputProcessor
{
    public class ProcessSequenceMoveTests
    {
        private ProcessSequenceMove _processSequenceMove;

        [Theory]
        [InlineData("R L M")]
        [InlineData("M")]
        public void Process_ShouldReturnCorrectMove(string line)
        {
            //Arrange
            _processSequenceMove = new ProcessSequenceMove(line);
            //Act
            var result = _processSequenceMove.Process().ToList();
            //Assert
            int i = 0;
            foreach (var move in line.Split(' '))
            {
                switch (move)
                {
                    case "R":
                        Assert.Equal(MoveBehaviorEnum.Right, result[i]);
                        break;
                    case "L":
                        Assert.Equal(MoveBehaviorEnum.Left, result[i]);
                        break;
                    case "M":
                        Assert.Equal(MoveBehaviorEnum.Move, result[i]);
                        break;
                }

                i++;
            }
        }

        [Fact]
        public void Process_ShouldThrowErrorIfInCorrectBehavior()
        {
            //Arrange
            var line = "L R M O B";
            _processSequenceMove = new ProcessSequenceMove(line);
            //Act & Assert
            Assert.Throws<InvalidDataException>(() => _processSequenceMove.Process().ToList());
        }
    }
}