using System;
using System.Drawing;
using Application.InputProcessor.Interfaces;
using Application.Utilities;

namespace Application.InputProcessor
{
    public class ProcessExitPoint : BaseProcessLine, IProcessLine<Point>
    {
        public ProcessExitPoint(string line) : base(line)
        {
            Line = line;
        }

        public Point Process()
        {
            var items = Line.Split(' ');

            if (items.Length == 2)
            {
                return new Point
                {
                    X = int.Parse(items[0]).ToPositiveInteger(),
                    Y = int.Parse(items[1]).ToPositiveInteger(),
                };
            }

            throw new ArgumentException("Exit point is null");
        }
    }
}