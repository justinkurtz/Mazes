using Mazes.Core;
using System.Collections.Generic;
using System.Linq;

namespace Mazes.Algorithms
{
    public class BinaryTree
    {
        public static Grid On(Grid grid)
        {
            foreach (Cell cell in grid)
            {
                var neighbors = new List<Cell>();

                if (cell.North != null)
                    neighbors.Add(cell.North);

                if (cell.East != null)
                    neighbors.Add(cell.East);

                if (neighbors.Any())
                {
                    cell.Link(neighbors.Random());
                }
            }

            return grid;
        }
    }
}
