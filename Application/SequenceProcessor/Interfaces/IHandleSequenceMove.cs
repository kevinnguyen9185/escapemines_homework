using System.Drawing;
using Application.InputProcessor.Models;
using Application.SequenceProcessor.Models;

namespace Application.SequenceProcessor.Interfaces
{
    public interface IHandleSequenceMove
    {
        ResultEnum Check(Position currentPosition, bool lastMoveCheck);

        Position Move(MoveBehaviorEnum currentBehavior, DirectionEnum currentDirection, Point currentPosition);
    }
}