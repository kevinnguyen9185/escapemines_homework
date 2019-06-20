using Application.InputProcessor.Models;
using Application.SequenceProcessor.Models;

namespace Application.SequenceProcessor.Interfaces
{
    public interface ICheckSequence
    {
        CheckResult CheckMove(Position currentPosition);
    }
}