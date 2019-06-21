using System;
using System.Drawing;
using Application.InputProcessor.Interfaces;
using Application.InputProcessor.Models;
using Application.Utilities;

namespace Application.InputProcessor
{
    /// <summary>
    /// X-columns, Y-rows
    /// </summary>
    public class ProcessBroadSize:BaseProcessLine, IProcessLine<BoardSize>
    {   
        public ProcessBroadSize(string line) : base(line)
        {
            _line = line;
        }
        public BoardSize Process()
        {
            var items = _line.Split(' ');

            if (items.Length == 2)
            {
                return new BoardSize
                {
                    Width = int.Parse(items[0]).ToPositiveInteger(),
                    Height = int.Parse(items[1]).ToPositiveInteger(),
                };
            }

            throw new ArgumentException("Board size is null");
        }
    }
}