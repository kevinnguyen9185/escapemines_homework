using System;
using Application.InputProcessor;
using Xunit;

namespace Application.UnitTests.InputProcessor
{
    public class ProcessExitPointTests
    {
        private ProcessExitPoint _processExitPoint;
        private string _line = "";
        
        [Fact]
        public void Process_ShouldReturnSize()
        {
            //Arrange
            _line = "4 5";
            _processExitPoint = new ProcessExitPoint(_line);
            //Act
            var result = _processExitPoint.Process();
            //Assert
            Assert.Equal(4, result.X);
            Assert.Equal(5, result.Y);
        }
        
        [Fact]
        public void Process_ShouldThrowErrorIfTooManyArguments()
        {
            //Arrange
            _line = "4 5 6";
            _processExitPoint = new ProcessExitPoint(_line);
            //Act && Assert
            Assert.Throws<ArgumentException>(() =>
                _processExitPoint.Process()
            );
        }
    }
}