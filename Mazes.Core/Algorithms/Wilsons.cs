using System;
using System.Collections.Generic;
using System.Linq;

namespace Mazes.Algorithms
{
    using Core;

    public class Wilsons
    {
        public static Grid On(Grid grid)
        {
            var unvisited = new List<Cell>();
            
            foreach (Cell cell in grid)
            {
                unvisited.Add(cell);
            }

            var first = unvisited.Random();
            unvisited.Remove(first);

            int j = 0;
            while (unvisited.Any())
            {
                var cell = unvisited.Random();
                var path = new List<Cell> { cell };

                while (unvisited.Contains(cell))
                {
                    cell = cell.Neighbors.Random();
                    var position = path.IndexOf(cell);
                    if (position >= 0)
                    {
                        path = path.Take(position+1).ToList();
                    }
                    else
                    {
                        path.Add(cell);
                    }
                }

                for (int i = 0; i < path.Count - 1; i++)
                {
                    path[i].Link(path[i + 1]);
                    unvisited.Remove(path[i]);
                }
            }

            return grid;
        }
    }
}
