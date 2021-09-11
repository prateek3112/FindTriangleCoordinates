using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Grid
    {
        public Grid()
        {
        }

        public Grid(int rows, int columns, int cellSize)
        {
            Rows = rows;
            Columns = columns;
            CellSize = cellSize;
        }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public int CellSize { get; set; }



    }
}
