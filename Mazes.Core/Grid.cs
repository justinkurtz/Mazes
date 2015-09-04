namespace Mazes.Core
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Grid : IEnumerable
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        private Cell[,] Cells { get; set; }

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new Cell[Rows, Columns];
            Init();
        }
        
        private void Init()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Cells[row, col] = new Cell(row, col);
                }
            }
        }

        public Cell GetRandomCell()
        {
            var rand = new Random();
            int row = rand.Next(Rows);
            int col = rand.Next(Columns);

            return Cells[row, col];
        }

        public IEnumerable<IEnumerable<Cell>> EachRow()
        {
            var allCells = this.Cast<Cell>();

            for (int row = 0; row < Rows; row++)
            {
                yield return allCells.Skip(row * Columns).Take(Columns);
            }
        }

        public int Count()
        {
            return Rows * Columns;
        }

        public IEnumerator GetEnumerator()
        {
            for(int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    yield return Cells[row, col];
                }
            }
        }

        public Cell this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows) return null;
                if (col < 0 || col >= Columns) return null;

                return Cells[row, col];
            }
        }

        protected virtual string ContentsOf(Cell cell)
        {
            return "   ";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("+");

            for(int i = 0; i < Columns; i++)
            {
                sb.Append("---+");
            }
            sb.AppendLine();

            foreach(var row in EachRow())
            {
                var top = new StringBuilder();
                top.Append("|");
                var bottom = new StringBuilder();
                bottom.Append("+");

                foreach(var cell in row)
                {
                    var east_boundary = cell.IsLinked(cell.East) ? " " : "|";
                    top.AppendFormat("{0}{1}", ContentsOf(cell), east_boundary);

                    var south_boundary = cell.IsLinked(cell.South) ? "   " : "---";
                    bottom.AppendFormat("{0}{1}", south_boundary, "+");
                }

                sb.AppendLine(top.ToString());
                sb.AppendLine(bottom.ToString());
            }

            return sb.ToString();
        }
    }
}
