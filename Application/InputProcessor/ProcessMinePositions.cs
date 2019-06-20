using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Application.InputProcessor.Interfaces;
using Application.Utilities;

namespace Application.InputProcessor
{
    public class ProcessMinePositions : BaseProcessLine, IProcessLine<IEnumerable<Point>>
    {
        public ProcessMinePositions(string line) : base(line)
        {
            _line = line;
        }
        
        public IEnumerable<Point> Process()
        {
            var minePositions = _line.Split(' ').ToList();

            foreach (var minePosition in minePositions)
            {
                var positions = minePosition.Split(',');
                if(positions.Length!=2) continue;
                yield return new Point
                {
                    X = int.Parse(positions[0]).ToPositiveInteger(),
                    Y = int.Parse(positions[1]).ToPositiveInteger(),
                };
            }
        }   
    }
}