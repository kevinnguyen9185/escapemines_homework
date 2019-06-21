using System.Drawing;
using Application.InputProcessor.Models;
using Application.SequenceProcessor.Models;

namespace Application.SequenceProcessor.Interfaces
{
    public interface IProcessSequence
    {
        ResultEnum ProcessGameSequences();
    }
}