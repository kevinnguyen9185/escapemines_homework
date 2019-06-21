using Application.InputProcessor.Models;

namespace Application.InputProcessor.Interfaces
{
    public interface IInputBuilder
    {
        GameSetting Build();
        void ReadText(string textFilePath);
        void ReadBoardSize();
        void ReadMinePosition();
        void ReadExitPoint();
        void ReadStartingPosition();
        void ReadSequences();
    }
}