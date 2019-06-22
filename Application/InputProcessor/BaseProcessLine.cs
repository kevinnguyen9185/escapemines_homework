using Check = Application.Utilities.Check;

namespace Application.InputProcessor
{
    public abstract class BaseProcessLine
    {
        protected string _line;
        
        protected BaseProcessLine(string line)
        {
            Check.NotNullOrEmpty(line, nameof(line));
            
            _line = line;
        }
    }
}