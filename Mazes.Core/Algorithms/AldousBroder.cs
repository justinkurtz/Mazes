using System.Linq;

namespace Mazes.Core.Algorithms
{
    public class AldousBroder
    {
        public static Grid On(Grid grid)
        {
            var cell = grid.GetRandomCell();
            var unvisited = grid.Count() - 1;

            while (unvisited > 0)
            {
                var neighbor = cell.Neighbors.Random();

                if (!neighbor.Links.Any())
                {
                    cell.Link(neighbor);
                    unvisited--;
                }

                cell = neighbor;
            }

            return grid;
        }
    }
}
