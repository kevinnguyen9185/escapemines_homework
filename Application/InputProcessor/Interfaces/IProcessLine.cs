namespace Application.InputProcessor.Interfaces
{
    public interface IProcessLine<out T>
    {
        T Process();
    }
}