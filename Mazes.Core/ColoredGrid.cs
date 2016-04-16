using System.Drawing;

namespace Mazes.Core
{
    public class ColoredGrid : Grid
    {
        private Distances _Distances { get; set; }

        public ColoredGrid(int rows, int columns) : base(rows, columns)
        {

        }
    }
}
