
namespace Mazes.Algorithms
{
    using Core;
    using System.Collections.Generic;
    using System.Linq;
    public class Wilsons
    {
        public static Grid On(Grid grid)
        {
            var unvisited = new List<Cell>();

            foreach (Cell cell in grid)
            {
                unvisited.Add(cell);
            }

            return null;
        }
    }
}
