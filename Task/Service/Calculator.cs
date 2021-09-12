using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Interface;
using Task.Models;

namespace Task.Service
{
    public class Calculator : ICalculator
    {

        
        

        public SingleTriangleProperties FindCoordinates(int row,int col,int cellsize, string type)
        {
            try
            {
                SingleTriangleProperties coordinates = new SingleTriangleProperties();

                

                var height = cellsize * 6;

                var nth = row * 10;

                decimal val1 = col / 2M;
                var bottomY = height - nth;

                int topY;
                if (type == "left")
                {

                    topY = bottomY + 10;

                    int bottomXL = (int)(Math.Floor(val1) * 10);

                    int bottomXR = (int)((Math.Floor(val1) * 10) + 10);
                    coordinates.AngularV1x = bottomXL;
                    coordinates.AngularV1y = bottomY;
                    coordinates.LeftV2x = bottomXL;
                    coordinates.LeftV2y = topY;
                    coordinates.RightV3x = bottomXR;
                    coordinates.RightV3y = bottomY;



                }

                if (type == "right")
                {

                    topY = bottomY + 10;



                    int topXL = ((int)(Math.Floor(val1) * 10));

                    var topXR = topXL + 10;

                    coordinates.AngularV1x = topXL;
                    coordinates.AngularV1y = topY;
                    coordinates.LeftV2x = topXL;
                    coordinates.LeftV2y = bottomY;
                    coordinates.RightV3x = topXL - 10;
                    coordinates.RightV3y = bottomY + 10;

                }



                return coordinates;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Triangle FindLocationFromVertices(SingleTriangleProperties request)
        {
            try
            {

                

                //if (request.AngularV1x == request.RightV3x || request.LeftV2x == request.RightV3x  || request.RightV3x == request.RightV3y )
                //{
                //    throw new Exception();
                //}

                Triangle triangle = new Triangle();





                if (request.AngularV1y < request.LeftV2y)
                {

                    triangle.Type = "left";

                    triangle.RowGiven = ((60 - (int)request.AngularV1y) / 10);

                    var m = request.AngularV1x / 10;

                    triangle.ColumnCalculated = (int)(m * 2) + 1;






                }

                else if (request.AngularV1y > request.LeftV2y)
                {
                    triangle.Type = "right";

                    triangle.RowGiven = ((60 - (int)request.AngularV1y) / 10) + 1;



                    var m = (request.AngularV1x / 10);

                    triangle.ColumnCalculated = (int)(m * 2);
                }

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
                    if (triangle.RowGiven == kvp.Key)
                    {
                        triangle.RowCalculated = kvp.Value;
                    }
                }

                if(triangle.RowGiven > 6 || triangle.ColumnCalculated > 12)
                {
                    throw new Exception("Please Enter Valid Coordinates");
                }

                return triangle;

            }
            catch (Exception)
            {

                throw;
            }
        }
    
    }
}
