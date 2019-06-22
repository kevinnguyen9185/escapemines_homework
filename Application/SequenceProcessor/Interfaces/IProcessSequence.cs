using System.Collections.Generic;
using Application.SequenceProcessor.Models;

namespace Application.SequenceProcessor.Interfaces
{
    public interface IProcessSequence
    {
        IEnumerable<CheckSequenceResult> ProcessGameSequences();
    }
}