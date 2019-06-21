using System;
using System.Drawing;
using Application.InputProcessor.Models;
using Application.SequenceProcessor.Interfaces;
using Application.SequenceProcessor.Models;
using Application.Utilities;

namespace Application.SequenceProcessor
{
    public class SequenceMoveHandler : IHandleSequenceMove
    {
        private readonly GameSetting _gameSetting;
        public SequenceMoveHandler(GameSetting gameSetting)
        {
            _gameSetting = gameSetting;
        }
        
        public ResultEnum Check(Position currentPosition, bool lastMoveCheck)
        {
            //Check mine
            if (_gameSetting.MinePositions.Contains(currentPosition.CurrentPosition))
            {
                return ResultEnum.MineHit;
            }

            //Check exit
            if (_gameSetting.ExitPoint == currentPosition.CurrentPosition)
            {
                return ResultEnum.Success;
            }
            
            //If nothing match and lastMoveCheck
            if (lastMoveCheck)
            {
                
            }

            return ResultEnum.Safe;
        }

        public Position Move(MoveBehaviorEnum currentBehavior, DirectionEnum currentDirection, Point currentPosition)
        {
            var nextPosition = currentPosition;
            var nextDirection = currentDirection.NextDirection(currentBehavior);
            if (currentBehavior == MoveBehaviorEnum.Move)
            {
                switch (nextDirection)
                {
                    case DirectionEnum.East:
                        nextPosition.X = currentPosition.X + 1;
                        break;
                    case DirectionEnum.West:
                        nextPosition.X = currentPosition.X - 1;
                        break;
                    case DirectionEnum.North:
                        nextPosition.Y = currentPosition.Y - 1;
                        break;
                    case DirectionEnum.South:
                        nextPosition.Y = currentPosition.Y + 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            // Check boundary of boarsize
            if (nextPosition.X < 0)
            {
                nextPosition.X = 0;
            }
            else if (nextPosition.X > _gameSetting.BoardSize.Width - 1)
            {
                nextPosition.X = _gameSetting.BoardSize.Width - 1;
            }

            if (nextPosition.Y < 0)
            {
                nextPosition.Y = 0;
            }
            else if (nextPosition.Y > _gameSetting.BoardSize.Height - 1)
            {
                nextPosition.Y = _gameSetting.BoardSize.Height - 1;
            }

            return new Position {Direction = nextDirection, CurrentPosition = nextPosition};
        }
    }
}