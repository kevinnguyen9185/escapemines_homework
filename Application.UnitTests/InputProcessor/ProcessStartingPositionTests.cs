using System;
using System.IO;
using System.Xml.XPath;
using Application.InputProcessor;
using Application.InputProcessor.Models;
using Xunit;
using Xunit.Sdk;

namespace Application.UnitTests.InputProcessor
{
    public class ProcessStartingPositionTests
    {
        private ProcessStartingPosition _processStartingPosition;
        private string _line = "";
        
        [Fact]
        public void Process_ShouldReturnPosition()
        {
            //Arrange
            _line = "0 1 N";
            _processStartingPosition = new ProcessStartingPosition(_line);
            //Act
            var result = _processStartingPosition.Process();
            //Assert
            Assert.Equal(0, result.CurrentCoordination.X);
            Assert.Equal(1, result.CurrentCoordination.Y);
            Assert.Equal(DirectionEnum.North, result.Direction);
        }
        
        [Fact]
        public void Process_ShouldThrowErrorIfTooManyArguments()
        {
            //Arrange
            _line = "4 5 6 7";
            _processStartingPosition = new ProcessStartingPosition(_line);
            //Act && Assert
            Assert.Throws<ArgumentException>(() =>
                _processStartingPosition.Process()
            );
        }
    }
}