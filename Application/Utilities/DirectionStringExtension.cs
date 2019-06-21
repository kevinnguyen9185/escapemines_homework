using System.IO;
using Application.InputProcessor.Models;

namespace Application.Utilities
{
    public static class DirectionStringExtension
    {
        public static DirectionEnum ToDirectionEnum(this string item)
        {
            switch (item)
            {
                case "N":
                    return DirectionEnum.North;
                case "S":
                    return DirectionEnum.South;
                case "W":
                    return DirectionEnum.West;
                case "E":
                    return DirectionEnum.East;
            }
            
            throw new InvalidDataException("Direction not in the list");
        }
    }
}