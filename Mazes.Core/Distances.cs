using System.Collections.Generic;
using System.Linq;

namespace Mazes.Core
{
    public class Distances
    {
        public int this[Cell cell]
        {
            get
            {
                int val;
                if (_Cells.TryGetValue(cell, out val))
                {
                    return val;
                }

                return -1;
            }
            set
            {
                _Cells[cell] = value;
            }
        }

        public IEnumerable<Cell> Cells
        {
            get { return _Cells.Keys; }
        }

        public int Max
        {
            get { return _Cells.Max(c => c.Value); }
        }

        private Dictionary<Cell, int> _Cells { get; set; }
        private Cell _Root { get; set; }

        public Distances(Cell root)
        {
            _Root = root;
            _Cells = new Dictionary<Cell, int>();
            _Cells[_Root] = 0;
        }

        public bool HasKey(Cell cell)
        {
            return _Cells.Keys.Any(c => c == cell);
        }
    }
}
