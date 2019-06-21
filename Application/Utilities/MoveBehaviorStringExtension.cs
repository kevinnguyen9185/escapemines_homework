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