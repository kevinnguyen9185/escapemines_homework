namespace Application.InputProcessor.Interfaces
{
    public interface IImportSource
    {
        string[] GetSource(string pathFile);
    }
}