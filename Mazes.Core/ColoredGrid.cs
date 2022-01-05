using System;
using System.Drawing;

namespace Mazes.Core
{
    public class ColoredGrid : Grid
    {
        private Distances distances;
        private int max;

        public Distances Distances
        {
            get => distances ??= new Distances(this[0, 0]);
            set
            {
                distances = value;
                max = distances.Max;
            }
        }

        public ColoredGrid(int rows, int columns) : base(rows, columns)
        {
        }

        protected override Brush BackgroundBrushFor(Cell cell)
        {
            if (max == 0)
            {
                return base.BackgroundBrushFor(cell);
            }
                
            var distance = Distances[cell];
            var intensity = Convert.ToDouble(max - distance) / max;
            var dark = Convert.ToInt32(255 * intensity);
            var bright = Convert.ToInt32(128 + (127 * intensity));

            return new SolidBrush(Color.FromArgb(dark, bright, dark));
        }
    }
}
