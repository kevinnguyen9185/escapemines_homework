using System.Collections.Generic;
using System.Linq;
using Application.InputProcessor.Interfaces;
using Application.InputProcessor.Models;

namespace Application.InputProcessor
{
    public class InputBuilder: IInputBuilder
    {
        private string[] _line = {""};
        private GameSetting _gameSetting;
        private readonly IImportSource _importSource;

        public InputBuilder(IImportSource importSource)
        {
            _importSource = importSource;
            _gameSetting = new GameSetting();
        }

        public GameSetting Build()
        {
            return _gameSetting;
        }

        public IInputBuilder ReadText(string textFilePath)
        {
            _line = _importSource.GetSource(textFilePath);
            return this;
        }

        public IInputBuilder ReadBoardSize()
        {
            //Process boardsize
            _gameSetting.BoardSize = new ProcessBroadSize(_line[0]).Process();
            return this;
        }

        public IInputBuilder ReadMinePosition()
        {
            //Process list of mines
            _gameSetting.MinePositions = new ProcessMinePositions(_line[1]).Process().ToList();
            return this;
        }

        public IInputBuilder ReadExitPoint()
        {
            //Process exit point
            _gameSetting.ExitPoint = new ProcessExitPoint(_line[2]).Process();
            return this;
        }

        public IInputBuilder ReadStartingPosition()
        {
            //Process starting position
            _gameSetting.StartingPosition = new ProcessStartingPosition(_line[3]).Process();
            return this;
        }

        public IInputBuilder ReadSequences()
        {
            //Process sequences
            _gameSetting.Sequences = new List<List<MoveBehaviorEnum>>();
            for (int i = 4; i < _line.Length; i++)
            {
                var sequences = new ProcessSequenceMove(_line[i]).Process().ToList();
                _gameSetting.Sequences.Add(sequences);
            }
            return this;
        }
    }
}