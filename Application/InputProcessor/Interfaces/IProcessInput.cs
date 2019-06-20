using Application.InputProcessor.Models;

namespace Application.InputProcessor.Interfaces
{
    public interface IProcessInput
    {
        GameSetting Process(string textFilePath);
    }
}