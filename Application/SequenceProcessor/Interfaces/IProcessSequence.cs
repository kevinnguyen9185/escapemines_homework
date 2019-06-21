using System.Drawing;
using Application.InputProcessor.Models;
using Application.SequenceProcessor.Models;

namespace Application.SequenceProcessor.Interfaces
{
    public interface IProcessSequence
    {
        CheckResult CheckPosition(Position currentPosition);

        Position Move(MoveBehaviorEnum currentBehavior, DirectionEnum currentDirection, Point currentPosition);
    }
}