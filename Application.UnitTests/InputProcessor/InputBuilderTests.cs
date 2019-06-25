using System;
using System.Drawing;
using Application.InputProcessor;
using Application.InputProcessor.Interfaces;
using Application.InputProcessor.Models;
using NSubstitute;
using Xunit;

namespace Application.UnitTests.InputProcessor
{
    public class InputBuilderTests
    {
        private InputBuilder _inputBuilder;
        private IImportSource _importSource;
        
        public InputBuilderTests()
        {
            _importSource = Substitute.For<IImportSource>();
            _inputBuilder = new InputBuilder(_importSource);
        }

        [Fact]
        public void InputBuilder_ShouldReturnGameSetting()
        {
            //Arrange
            _importSource.GetSource("").ReturnsForAnyArgs(new string[]
            {
                "5 4",
                "1,1 1,3 3,3",
                "4 2",
                "0 1 N",
                "R M L M M",
                "R M M M"
            });
            //Act
            var gameSetting =
                _inputBuilder
                    .ReadText("sample")
                    .ReadBoardSize()
                    .ReadMinePosition()
                    .ReadExitPoint()
                    .ReadStartingPosition()
                    .ReadSequences()
                    .Build();
            //Assert
            Assert.Equal(4, gameSetting.BoardSize.Width);
            Assert.Equal(5, gameSetting.BoardSize.Height);
            Assert.Equal(3, gameSetting.MinePositions.Count);
            Assert.Equal(new Point(4, 2), gameSetting.ExitPoint);
            Assert.Equal(new Point(0, 1), gameSetting.StartingPosition.CurrentPosition);
            Assert.Equal(DirectionEnum.North, gameSetting.StartingPosition.Direction);
            Assert.Equal(2, gameSetting.Sequences.Count);
        }
        
        [Fact]
        public void InputBuilder_ShouldThrowError()
        {
            //Arrange
            _importSource.GetSource("").ReturnsForAnyArgs(new string[]
            {
                "5 4",
                "1,1 1,3 3,3",
                "42",
                "0 1 N",
                "R M L M M",
                "R M M M"
            });
            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _inputBuilder
                    .ReadText("sample")
                    .ReadBoardSize()
                    .ReadMinePosition()
                    .ReadExitPoint()
                    .ReadStartingPosition()
                    .ReadSequences()
                    .Build();
            });
        }
    }
}