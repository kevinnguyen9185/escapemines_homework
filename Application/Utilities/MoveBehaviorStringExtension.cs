using System.IO;
using Application.InputProcessor.Models;

namespace Application.Utilities
{
    public static class MoveBehaviorStringExtension
    {
        public static MoveBehaviorEnum ToMoveBehaviorEnum(this string behavior)
        {
            switch (behavior)
            {
                case "N":
                    return MoveBehaviorEnum.North;
                case "S":
                    return MoveBehaviorEnum.South;
                case "W":
                    return MoveBehaviorEnum.West;
                case "E":
                    return MoveBehaviorEnum.East;
                case "M":
                    return MoveBehaviorEnum.Move;
                case "L":
                    return MoveBehaviorEnum.Left;
                case "R":
                    return MoveBehaviorEnum.Right;
            }

            throw new InvalidDataException("Behavior not in the list");
        }
    }
}