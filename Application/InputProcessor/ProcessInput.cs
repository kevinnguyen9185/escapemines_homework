using System.Collections.Generic;
using System.IO;
using System.Linq;
using Application.InputProcessor.Interfaces;
using Application.InputProcessor.Models;
using Core;

namespace Application.InputProcessor
{
    public class ProcessInput: IProcessInput
    {
        public GameSetting Process(string textFilePath)
        {
            Check.NotNullOrEmpty(textFilePath, nameof(textFilePath));
            
            var gameSetting = new GameSetting();
            
            var lines = File.ReadAllLines(textFilePath);

            if (lines.Length < 5)
            {
                return null;
            }
            
            //Process boardsize
            gameSetting.BoardSize = new ProcessBroadSize(lines[0]).Process();
            //Process list of mines
            gameSetting.MinePositions = new ProcessMinePositions(lines[1]).Process().ToList();
            //Process exit point
            gameSetting.ExitPoint = new ProcessExitPoint(lines[2]).Process();
            //Process starting position
            gameSetting.StartingPosition = new ProcessStartingPosition(lines[3]).Process();
            //Process sequences
            gameSetting.Sequences = new List<List<MoveBehaviorEnum>>();
            for (int i = 4; i < lines.Length; i++)
            {
                var sequences = new ProcessSequenceMove(lines[i]).Process().ToList();
                gameSetting.Sequences.Add(sequences);
            }

            return gameSetting;
        }
    }
}