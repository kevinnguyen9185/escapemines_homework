using System;
using Application.InputProcessor.Models;

namespace Application.Utilities
{
    public static class DirectionFromBehaviorExtension
    {
        public static DirectionEnum NextDirection(this DirectionEnum currentDirection, MoveBehaviorEnum behavior)
        {
            if (behavior == MoveBehaviorEnum.Move)
            {
                return currentDirection;
            }
            
            var newDirectionPos = (int) currentDirection;
            if (behavior == MoveBehaviorEnum.Left)
            {
                newDirectionPos = (int) currentDirection - 1;
            }
            else if(behavior == MoveBehaviorEnum.Right)
            {
                newDirectionPos = (int) currentDirection + 1;
            }

            if (newDirectionPos < 1)
            {
                newDirectionPos = 4;
            }
            else if (newDirectionPos > 4)
            {
                newDirectionPos = 1;
            }

            return (DirectionEnum) Enum.Parse(typeof(DirectionEnum), newDirectionPos.ToString());
        }
    }
}