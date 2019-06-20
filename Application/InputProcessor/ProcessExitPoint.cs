using System;
using System.Drawing;
using System.IO;
using Application.InputProcessor.Interfaces;
using Application.Utilities;
using Core;

namespace Application.InputProcessor
{
    public class ProcessExitPoint : BaseProcessLine, IProcessLine<Point>
    {
        public ProcessExitPoint(string line) : base(line)
        {
            _line = line;
        }

        public Point Process()
        {
            var items = _line.Split(' ');

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