using System;

namespace Mazes.Core.Algorithms
{
    public class RecursiveDivision
    {
        private static Random rand = new();
        private static Grid dividingGrid { get; set; }

        public static Grid On(Grid grid)
        {
            dividingGrid = grid;

            foreach (Cell cell in grid)
            {
                cell.Neighbors.ForEach(n => cell.Link(n, false));
            }

            Divide(0, 0, grid.Rows, grid.Columns);
            return grid;
        }

        private static void Divide(int row, int col, int height, int width)
        {
            if (height <= 1 || width <= 1)
                return;

            if (height > width)
            {
                DivideHorizontally(row, col, height, width);
            }
            else
            {
                DivideVertically(row, col, height, width);
            }
        }

        private static void DivideHorizontally(int row, int column, int height, int width)
        {
            var divideSouthOf = rand.Next(height - 1);
            var passageAt = rand.Next(width);
            for (var i = 0; i < width; i++)
            {
                if (passageAt == i)
                    continue;

                var cell = dividingGrid[row + divideSouthOf, column + i];
                cell.Unlink(cell.South);
            }

            Divide(row, column, divideSouthOf + 1, width);
            Divide(row + divideSouthOf + 1, column, height - divideSouthOf - 1, width);
        }

        private static void DivideVertically(int row, int column, int height, int width)
        {
            var divideEastOf = rand.Next(width - 1);
            var passageAt = rand.Next(height);

            for (var i = 0; i < height; i++)
            {
                if (passageAt == i)
                    continue;

                var cell = dividingGrid[row + i, column + divideEastOf];
                cell.Unlink(cell.East);
            }

            Divide(row, column, height, divideEastOf + 1);
            Divide(row, column + divideEastOf + 1, height, width - divideEastOf - 1);
        }
    }
}
