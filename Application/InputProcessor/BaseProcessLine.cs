using Check = Application.Utilities.Check;

namespace Application.InputProcessor
{
    public abstract class BaseProcessLine
    {
        protected string Line;
        
        protected BaseProcessLine(string line)
        {
            Check.NotNullOrEmpty(line, nameof(line));
            
            Line = line;
        }
    }
}