using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Triangle
    {
        public Triangle()
        {
        }

        public Triangle(int rowGiven, int columnGiven)
        {
            RowGiven = rowGiven;
            ColumnGiven = columnGiven;
        }

        public int RowGiven { get; set; }
        public int ColumnGiven { get; set; }

        public string Type { get; set; }

        public char RowCalculated {get; set;}

        public int ColumnCalculated { get; set; }

        public SingleTriangleProperties Coordinates { get; set; }

    }
}
