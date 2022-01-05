using System.Collections.Generic;
using System.Linq;

namespace Mazes.Core.Algorithms
{
    public class RecursiveBacktracker
    {
        public static Grid On(Grid grid, Cell start = null)
        {
            start ??= grid.GetRandomCell();

            var stack = new Stack<Cell>();
            stack.Push(start);

            while(stack.Any())
            {
                var current = stack.Peek();
                var neighbors = current.Neighbors.Where(n => !n.Links.Any());

                if (neighbors.Any())
                {
                    var neighbor = neighbors.Random();
                    current.Link(neighbor);
                    stack.Push(neighbor);
                }
                else
                {
                    stack.Pop();
                }
            }

            return grid;
        }
    }
}
