using System;
using System.IO;
using Application.InputProcessor;
using Xunit;
using Xunit.Sdk;

namespace Application.UnitTests.InputProcessor
{
    public class ProcessBoardSizeTests
    {
        private ProcessBroadSize _processBroadSize;
        private string _line = "";
        
        [Fact]
        public void Process_ShouldReturnSize()
        {
            //Arrange
            _line = "4 5";
            _processBroadSize = new ProcessBroadSize(_line);
            //Act
            var result = _processBroadSize.Process();
            //Assert
            Assert.Equal(4, result.Width);
            Assert.Equal(5, result.Height);
        }
        
        [Fact]
        public void Process_ShouldThrowErrorIfTooManyArguments()
        {
            //Arrange
            _line = "4 5 6";
            _processBroadSize = new ProcessBroadSize(_line);
            //Act && Assert
            Assert.Throws<ArgumentException>(() =>
                _processBroadSize.Process()
            );
        }
    }
}