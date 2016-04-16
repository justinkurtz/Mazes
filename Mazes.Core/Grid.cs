using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Mazes.Core
{
    public class Grid : IEnumerable
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        private Cell[,] _Cells { get; set; }
        private static Random random = new Random();

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _Cells = new Cell[Rows, Columns];

            Init();
        }

        private void Init()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    _Cells[row, col] = new Cell(row, col);
                }
            }

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    _Cells[row, col].North = this[row - 1, col];
                    _Cells[row, col].South = this[row + 1, col];
                    _Cells[row, col].East = this[row, col + 1];
                    _Cells[row, col].West = this[row, col - 1];
                }
            }
        }

        public Cell GetRandomCell()
        {
            int row = random.Next(Rows);
            int col = random.Next(Columns);

            return _Cells[row, col];
        }

        public Cell GetCenterCell()
        {
            return _Cells[Rows / 2, Columns / 2];
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
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    yield return _Cells[row, col];
                }
            }
        }

        public Cell this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows) return null;
                if (col < 0 || col >= Columns) return null;

                return _Cells[row, col];
            }
        }

        protected virtual string ContentsOf(Cell cell)
        {
            return "   ";
        }

        protected virtual Brush BackgroundBrushFor(Cell cell)
        {
            return Brushes.White;
        }

        public Bitmap ToBitmap(int cellSize = 20)
        {
            var bitmap = new Bitmap(cellSize * Columns + 1, cellSize * Rows + 1);
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);

                // Paint the backgrounds
                foreach (Cell cell in this)
                {
                    var x1 = cell.Column * cellSize;
                    var y1 = cell.Row * cellSize;
                    var x2 = (cell.Column + 1) * cellSize;
                    var y2 = (cell.Row + 1) * cellSize;

                    var color = BackgroundBrushFor(cell);
                    if (color != Brushes.White)
                    {
                        graphic.FillRectangle(color, new Rectangle { X = x1, Y = y1, Width = x2 - x1, Height = y2 - y1 });
                    }
                }

                // Paint the walls
                foreach (Cell cell in this)
                {
                    var x1 = cell.Column * cellSize;
                    var y1 = cell.Row * cellSize;
                    var x2 = (cell.Column + 1) * cellSize;
                    var y2 = (cell.Row + 1) * cellSize;

                    var pen = Pens.Black;
                    if (!cell.IsLinked(cell.North))
                    {
                        graphic.DrawLine(pen, new Point { X = x1, Y = y1 }, new Point { X = x2, Y = y1 });
                    }
                    if (!cell.IsLinked(cell.West))
                    {
                        graphic.DrawLine(pen, new Point { X = x1, Y = y1 }, new Point { X = x1, Y = y2 });
                    }
                    if (!cell.IsLinked(cell.East))
                    {
                        graphic.DrawLine(pen, new Point { X = x2, Y = y1 }, new Point { X = x2, Y = y2 });
                    }
                    if (!cell.IsLinked(cell.South))
                    {
                        graphic.DrawLine(pen, new Point { X = x1, Y = y2 }, new Point { X = x2, Y = y2 });
                    }
                }

                graphic.Save();
            }

            return bitmap;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("+");

            for (int i = 0; i < Columns; i++)
            {
                sb.Append("---+");
            }

            sb.AppendLine();

            foreach (var row in EachRow())
            {
                var top = new StringBuilder();
                top.Append("|");
                var bottom = new StringBuilder();
                bottom.Append("+");

                foreach (var cell in row)
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
