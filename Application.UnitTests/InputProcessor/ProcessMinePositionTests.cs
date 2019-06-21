using System;
using System.Linq;
using Application.InputProcessor;
using Application.InputProcessor.Models;
using Xunit;

namespace Application.UnitTests.InputProcessor
{
    public class ProcessMinePositionTests
    {
        private ProcessMinePositions _processMinePositions;
        private string _line = "";
        
        [Fact]
        public void Process_ShouldReturnPosition()
        {
            //Arrange
            _line = "0,0 1,2 2,3";
            _processMinePositions = new ProcessMinePositions(_line);
            //Act
            var result = _processMinePositions.Process().ToList();
            //Assert
            Assert.Equal(3, result.Count());
            Assert.Equal(0, result[0].X);
            Assert.Equal(0, result[0].Y);
        }
    }
}