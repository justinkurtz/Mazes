using System;
using System.Collections.Generic;

namespace Mazes.Core.Algorithms
{
    public class Sidewinder
    {
        private static Random rand = new Random();

        public static Grid On(Grid grid)
        {
            foreach (var row in grid.EachRow())
            {
                var run = new List<Cell>();

                foreach(var cell in row)
                {
                    run.Add(cell);
                    var closeOut = cell.East == null || (cell.North != null && rand.Next(2) == 0);

                    if (closeOut)
                    {
                        var member = run.Random();
                        if (member.North != null)
                        {
                            member.Link(member.North);
                        }
                        run.Clear();
                    }
                    else
                    {
                        cell.Link(cell.East);
                    }
                }
            }

            return grid;
        }
    }
}
