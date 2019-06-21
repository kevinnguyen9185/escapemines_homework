using System.Collections.Generic;
using System.IO;
using System.Linq;
using Application.InputProcessor.Interfaces;
using Application.InputProcessor.Models;
using Core;

namespace Application.InputProcessor
{
    public class InputBuilder: IInputBuilder
    {
        private string[] _line = {""};
        private GameSetting _gameSetting = new GameSetting();

        public GameSetting Build()
        {
            return _gameSetting;
        }

        public void ReadText(string textFilePath)
        {
            Check.NotNullOrEmpty(textFilePath, nameof(textFilePath));

            var lines = File.ReadAllLines(textFilePath);

            if (lines.Length < 5)
            {
                throw new InvalidDataException();
            }
        }

        public void ReadBoardSize()
        {
            //Process boardsize
            _gameSetting.BoardSize = new ProcessBroadSize(_line[0]).Process();
        }

        public void ReadMinePosition()
        {
            //Process list of mines
            _gameSetting.MinePositions = new ProcessMinePositions(_line[1]).Process().ToList();
        }

        public void ReadExitPoint()
        {
            //Process exit point
            _gameSetting.ExitPoint = new ProcessExitPoint(_line[2]).Process();
        }

        public void ReadStartingPosition()
        {
            //Process starting position
            _gameSetting.StartingPosition = new ProcessStartingPosition(_line[3]).Process();
        }

        public void ReadSequences()
        {
            //Process sequences
            _gameSetting.Sequences = new List<List<MoveBehaviorEnum>>();
            for (int i = 4; i < _line.Length; i++)
            {
                var sequences = new ProcessSequenceMove(_line[i]).Process().ToList();
                _gameSetting.Sequences.Add(sequences);
            }
        }
    }
}