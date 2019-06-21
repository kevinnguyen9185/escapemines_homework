using Application.InputProcessor.Models;

namespace Application.InputProcessor.Interfaces
{
    public interface IInputBuilder
    {
        GameSetting Build();
        IInputBuilder ReadText(string textFilePath);
        IInputBuilder ReadBoardSize();
        IInputBuilder ReadMinePosition();
        IInputBuilder ReadExitPoint();
        IInputBuilder ReadStartingPosition();
        IInputBuilder ReadSequences();
    }
}