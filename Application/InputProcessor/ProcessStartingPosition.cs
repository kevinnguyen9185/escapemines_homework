using System;
using System.Drawing;
using Application.InputProcessor.Interfaces;
using Application.InputProcessor.Models;
using Application.Utilities;

namespace Application.InputProcessor
{
    public class ProcessStartingPosition :BaseProcessLine, IProcessLine<Position>
    {
        public ProcessStartingPosition(string line) : base(line)
        {
            Line = line;
        }
        
        public Position Process()
        {
            var items = Line.Split(' ');

            if (items.Length == 3)
            {
                return new Position
                {
                    CurrentPosition = new Point
                    {
                        X = int.Parse(items[0]).ToPositiveInteger(),
                        Y = int.Parse(items[1]).ToPositiveInteger()
                    },
                    Direction = items[2].ToDirectionEnum()
                };
            }

            throw new ArgumentException("Starting position is null");
        }
    }
}