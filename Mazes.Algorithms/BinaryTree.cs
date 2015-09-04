using Mazes.Core;
using System;
using System.Collections.Generic;

namespace Mazes.Algorithms
{
    public class BinaryTree
    {
        public static Grid On(Grid grid)
        {
            var rand = new Random();
            foreach(Cell cell in grid)
            {
                var neighbors = new List<Cell>();

                if (cell.North != null)
                    neighbors.Add(cell.North);

                if (cell.East != null)
                    neighbors.Add(cell.East);

                if (neighbors.Count > 0)
                {
                    var index = rand.Next(neighbors.Count);
                    var neighbor = neighbors[index];

                    cell.Link(neighbor);
                }
            }

            return grid;
        }
    }
}
