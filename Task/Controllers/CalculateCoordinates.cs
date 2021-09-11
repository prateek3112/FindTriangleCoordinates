using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Interface;
using Task.Models;
using Task.Service;

namespace Task.Controllers
{
    
    [ApiController]
    public class CalculateCoordinates : ControllerBase
    {
        private readonly ICalculator _calc;

       

        public CalculateCoordinates(ICalculator calculator)
        {
            _calc = calculator;
        }

        [HttpGet("getCordinates")]
        public Triangle getCordinates([FromQuery]char row, int column)
        {

            
            var rownumber = 0; 
            var r = char.ToUpper(row);
            
            Dictionary<int, char> dict = new Dictionary<int, char>
        {
            { 1, 'A' },
            { 2, 'B' },
             { 3, 'C' },
            { 4, 'D' },
             { 5, 'E' },
            { 6, 'F' },

        };

            foreach (var kvp in dict)
            {
                if (r == kvp.Value)
                {
                    rownumber = kvp.Key;
                }
            }

            if (rownumber > 6 || rownumber < 0 || column < 0 || column > 12)
            {
                throw new Exception("Enter Row Value Between 1-6");
            }

            try
            {
                Triangle triangle = new Triangle()
                {
                    RowGiven = rownumber,
                    ColumnGiven = column

                };

                Grid grid = new Grid()
                {
                    Rows = 6,
                    Columns = 12,
                    CellSize = 10

                };



                if (column % 2 == 0)
                {
                    triangle.Type = "right";
                }
                else
                {
                    triangle.Type = "left";
                }

                var W = triangle.Type;
                SingleTriangleProperties cords = this._calc.FindCoordinates(rownumber, column, 10, W);

                triangle.Coordinates = cords;

                return triangle;

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("getLocation")]
        public Triangle getLocation(SingleTriangleProperties request)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            if (request.AngularV1x % 10 != 0 || request.AngularV1y % 10 != 0 || request.LeftV2x % 10 != 0 || request.LeftV2y % 10 != 0 || request.RightV3x % 10 != 0 || request.RightV3y % 10 != 0)
            {
                throw new Exception("Please enter Valid Points");

            }
            
            try
            {


                Triangle cords = this._calc.FindLocationFromVertices(request);

                return cords;

            }
            catch (Exception e)
            {
                throw new Exception("Error in Finding Location!",e);
            }

        }

    }
}
