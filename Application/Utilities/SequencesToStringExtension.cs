using System.Collections.Generic;
using Application.InputProcessor.Models;

namespace Application.Utilities
{
    public static class SequencesToStringExtension
    {
        public static string ToSequenceString(this IEnumerable<MoveBehaviorEnum> sequences)
        {
            var sequenceString = "";
            foreach (var sequence in sequences)
            {
                sequenceString += sequence.ToString() + " ";
            }

            return sequenceString;
        }
    }
}