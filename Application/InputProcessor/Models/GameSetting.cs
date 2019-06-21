using System.Collections.Generic;
using System.Drawing;

namespace Application.InputProcessor.Models
{
    public class GameSetting
    {
        public BoardSize BoardSize { get; set; }

        public List<Point> MinePositions { get; set; }

        public Point ExitPoint { get; set; }

        public Position StartingPosition { get; set; }

        public List<List<MoveBehaviorEnum>> Sequences { get; set; }
    }
}