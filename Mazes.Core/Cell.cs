using System.Collections.Generic;

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

        public Cell()
        {
            Links = new Dictionary<Cell, bool>();
        }

        public Cell(int row, int column) : this()
        {
            Row = row;
            Column = column;
        }

        public Cell Link(Cell cell, bool bidirectional = true)
        {
            Links[cell] = true;

            if (bidirectional)
            {
                cell.Link(this, false);
            }

            return this;
        }

        public bool IsLinked(Cell cell)
        {
            return cell != null && Links.ContainsKey(cell) && Links[cell];
        }

        public Cell Unlink(Cell cell, bool bidirectional = true)
        {
            Links[cell] = false;

            if (bidirectional)
            {
                cell.Unlink(this, false);
            }

            return this;
        }

        private Dictionary<Cell, bool> Links { get; set; }
    }
}
