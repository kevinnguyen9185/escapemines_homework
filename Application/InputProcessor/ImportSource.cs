using System.IO;
using Application.InputProcessor.Interfaces;
using Check = Application.Utilities.Check;

namespace Application.InputProcessor
{
    public class ImportFileSource : IImportSource
    {
        public string[] GetSource(string filePath)
        {
            Check.NotNullOrEmpty(filePath, nameof(filePath));

            var lines = File.ReadAllLines(filePath);

            if (lines.Length < 5)
            {
                throw new InvalidDataException();
            }

            return lines;
        }
    }
}