using System;
using System.Drawing;
using System.IO;
using Application.InputProcessor.Interfaces;
using Application.InputProcessor.Models;
using Core;
using Application.Utilities;

namespace Application.InputProcessor
{
    public class ProcessStartingPosition :BaseProcessLine, IProcessLine<Position>
    {
        public ProcessStartingPosition(string line) : base(line)
        {
            _line = line;
        }
        
        public Position Process()
        {
            var items = _line.Split(' ');

            if (items.Length == 3)
            {
                return new Position
                {
                    CurrentCoordination = new Point
                    {
                        X = int.Parse(items[0]).ToPositiveInteger(),
                        Y = int.Parse(items[1]).ToPositiveInteger()
                    },
                    MoveBehaviorEnum = items[2].ToMoveBehaviorEnum()
                };
            }

            throw new ArgumentException("Starting position is null");
        }
    }
}