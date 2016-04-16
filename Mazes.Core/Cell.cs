using System.Collections.Generic;
using System.Linq;

namespace Mazes.Core
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Cell East { get; set; }
        public Cell West { get; set; }
        public Cell North { get; set; }
        public Cell South { get; set; }
        
        public Distances Distances
        {
            get
            {
                var distances = new Distances(this);
                var frontier = new List<Cell>() { this };

                while(frontier.Any())
                {
                    var newFrontier = new List<Cell>();

                    foreach (var cell in frontier)
                    {
                        foreach (var linked in cell.Links)
                        {
                            if (distances.HasKey(linked))
                                continue;

                            distances[linked] = distances[cell] + 1;
                            newFrontier.Add(linked);
                        }
                    }

                    frontier = newFrontier;
                }

                return distances;
            }
        }

        public IEnumerable<Cell> Links
        {
            get { return _Links.Keys; }
        }

        private Dictionary<Cell, bool> _Links { get; set; }

        public Cell()
        {
            _Links = new Dictionary<Cell, bool>();
        }

        public Cell(int row, int column) : this()
        {
            Row = row;
            Column = column;
        }

        public Cell Link(Cell cell, bool bidirectional = true)
        {
            _Links[cell] = true;

            if (bidirectional)
            {
                cell.Link(this, false);
            }

            return this;
        }

        public bool IsLinked(Cell cell)
        {
            return cell != null && _Links.ContainsKey(cell) && _Links[cell];
        }

        public Cell Unlink(Cell cell, bool bidirectional = true)
        {
            _Links[cell] = false;

            if (bidirectional)
            {
                cell.Unlink(this, false);
            }

            return this;
        }
    }
}
