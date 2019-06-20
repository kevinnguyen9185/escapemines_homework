using Application.InputProcessor.Models;

namespace Application.SequenceProcessor.Models
{
    public class CheckResult
    {
        public Position NextPosition { get; set; }
        public ResultEnum Result { get; set; }
    }
}