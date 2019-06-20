using System.IO;

namespace Application.Utilities
{
    public static class IntegerToPositiveIntergerCheckExtension
    {
        public static int ToPositiveInteger(this int number)
        {
            return number >= 0
                ? number
                : throw new InvalidDataException("Not allow negative number");
        }
    }
}