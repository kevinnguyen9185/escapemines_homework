using System.Drawing;

namespace Application.InputProcessor.Models
{
    public class Position
    {
        public Point CurrentPosition { get; set; }
        public DirectionEnum Direction { get; set; }
    }
}