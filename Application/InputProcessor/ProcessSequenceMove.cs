using System.Collections.Generic;
using Application.InputProcessor.Interfaces;
using Application.InputProcessor.Models;
using Application.Utilities;

namespace Application.InputProcessor
{
    public class ProcessSequenceMove :BaseProcessLine, IProcessLine<IEnumerable<MoveBehaviorEnum>>
    {
        public ProcessSequenceMove(string line) : base(line)
        {
            Line = line;
        }
        
        public IEnumerable<MoveBehaviorEnum> Process()
        {
            var items = Line.Split(' ');

            foreach (var item in items)
            {
                yield return item.ToMoveBehaviorEnum();
            }
        }
    }
}