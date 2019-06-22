using System.Collections.Generic;
using Application.InputProcessor.Models;

namespace Application.SequenceProcessor.Models
{
    public class CheckSequenceResult
    {
        public IEnumerable<MoveBehaviorEnum> Sequences { get; set; }
        public ResultEnum Result { get; set; }
    }
}