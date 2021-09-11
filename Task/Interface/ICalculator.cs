using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Interface
{
    public interface ICalculator
    {
        

        public SingleTriangleProperties FindCoordinates(int row, int col, int cellsize, string type);

        public Triangle FindLocationFromVertices(SingleTriangleProperties request);

    }
}
