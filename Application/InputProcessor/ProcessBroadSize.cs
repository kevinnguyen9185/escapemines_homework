using System;
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
            Line = line;
        }
        public BoardSize Process()
        {
            var items = Line.Split(' ');

            if (items.Length == 2)
            {
                return new BoardSize
                {
                    Height = int.Parse(items[0]).ToPositiveInteger(),
                    Width = int.Parse(items[1]).ToPositiveInteger(),
                };
            }

            throw new ArgumentException("Board size is null");
        }
    }
}