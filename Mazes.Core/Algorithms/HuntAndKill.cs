using System.Linq;

namespace Mazes.Core.Algorithms
{
    public class HuntAndKill
    {
        public static Grid On(Grid grid)
        {
            var current = grid.GetRandomCell();

            while (current != null)
            {
                var unvisitedNeighbors = current.Neighbors.Where(n => !n.Links.Any());

                if (unvisitedNeighbors.Any())
                {
                    var neighbor = unvisitedNeighbors.Random();
                    current.Link(neighbor);
                    current = neighbor;
                }
                else
                {
                    current = null;

                    foreach (Cell cell in grid)
                    {
                        var visitedNeighbors = cell.Neighbors.Where(n => n.Links.Any());
                        if (!cell.Links.Any() && visitedNeighbors.Any())
                        {
                            current = cell;
                            var neighbor = visitedNeighbors.Random();
                            current.Link(neighbor);
                            break;
                        }
                    }
                }
            }

            return grid;
        }
    }
}
