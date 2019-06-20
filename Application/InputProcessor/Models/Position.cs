using System.Drawing;

namespace Application.InputProcessor.Models
{
    public class Position
    {
        public Point CurrentCoordination { get; set; }
        public MoveBehaviorEnum MoveBehaviorEnum { get; set; }
    }
}