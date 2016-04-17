using System.Collections.Generic;
using System.Linq;

namespace Mazes.Core.Algorithms
{
    public class GrowingTree
    {
        public static Grid On(Grid grid, Cell start = null)
        {
            if (start == null)
            {
                start = grid.GetRandomCell();
            }

            var active = new List<Cell>();
            active.Add(start);

            while(active.Any())
            {
                var cell = active.Last();
                var neighbors = cell.Neighbors.Where(n => !n.Links.Any());

                if (neighbors.Any())
                {
                    var neighbor = neighbors.Random();
                    cell.Link(neighbor);
                    active.Add(neighbor);
                }
                else
                {
                    active.Remove(cell);
                }
            }

            return grid;
        }
    }
}
