using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using Application.InputProcessor.Interfaces;
using Application.Utilities;
using Core;

namespace Application.InputProcessor
{
    /// <summary>
    /// X-columns, Y-rows
    /// </summary>
    public class ProcessBroadSize:BaseProcessLine, IProcessLine<Point>
    {   
        public ProcessBroadSize(string line) : base(line)
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

            throw new ArgumentException("Board size is null");
        }
    }
}