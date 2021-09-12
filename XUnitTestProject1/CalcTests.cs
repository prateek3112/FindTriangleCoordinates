using Microsoft.AspNetCore.Mvc;
using Moq;

using System;
using Task.Controllers;
using Task.Interface;
using Task.Models;
using Task.Service;
using Xunit;

namespace XUnitTestProject1
{
    public class CalcTests
    {
        private readonly Calculator _calc = null;

        private readonly Mock<ICalculator> service;
        public CalcTests()
        {
            if(_calc == null)
            {
                _calc = new Calculator();

            }
            service = new Mock<ICalculator>();
        }


        [Fact]
        public void ThrowsErrorForInvalidRowORCol()
        {
            char row = 'g';
            int col = 14;

            var cc = new CalculateCoordinates(service.Object);

            Assert.Throws<Exception>(() => cc.getCordinates(row, col));

        }

        [Fact]
        public void ThrowsErrorForEmptyRequest()
        {
            var request = new SingleTriangleProperties(); 

            var cc = new CalculateCoordinates(service.Object);

            Assert.Throws<ArgumentNullException>(() => cc.getLocation(null));

        }

        

        [Fact]
        public void ThrowsErrorifCoordinatesnotMultipleOf10()
        {
            var request = new SingleTriangleProperties()
            {
                AngularV1x = 1,
                AngularV1y = 2,
                LeftV2x = 3,
                LeftV2y = 4,
                RightV3x = 5,
                RightV3y = 6
            };
            

            var cc = new CalculateCoordinates(service.Object);

            Assert.Throws<Exception>(() => cc.getLocation(request));

        }

        [Fact]
        public void ReturnsCorrectOutputWithvalidinputs()
        {

            int row = 1;
            char rownumber = 'A';
            int col = 12;

            var coordinates = new SingleTriangleProperties()
            {
                AngularV1x = 60,
                AngularV1y = 60,
                LeftV2x = 60,
                LeftV2y = 50,
                RightV3x = 50,
                RightV3y = 60
            };


            
            service.Setup(x => x.FindCoordinates(row,col,10,"right")).Returns(coordinates);
            var calc = new CalculateCoordinates(service.Object);

            //act
            var okResult = calc.getCordinates(rownumber, col);
            var resObj = okResult as OkObjectResult;
            var actualResult = resObj.Value;
            var Result = actualResult as Triangle;

            

            Assert.Equal(Result.Coordinates, coordinates);
        }


        [Fact]
        public void ReturnsTriangleWithvalidinputs()
        {

            var request = new SingleTriangleProperties()
            {
                AngularV1x = 60,
                AngularV1y = 60,
                LeftV2x = 60,
                LeftV2y = 50,
                RightV3x = 50,
                RightV3y = 60
            };
            var res = new Triangle()
            {
                RowCalculated = 'A',
                ColumnCalculated = 12
            };
            service.Setup(x => x.FindLocationFromVertices(request)).Returns(res);
            var calc = new CalculateCoordinates(service.Object);

            //act
            var okResult = calc.getLocation(request);
            var resObj = okResult as OkObjectResult;
            var actualResult = resObj.Value;
            var Result = actualResult as Triangle;

            Assert.Equal(Result, res);
        }

        [Fact]
        public void ThrowsErrorIfNotMultipleOf10()
        {

           

            var request = new SingleTriangleProperties()
            {
                AngularV1x = 6,
                AngularV1y = 6,
                LeftV2x = 6,
                LeftV2y = 2,
                RightV3x = 1,
                RightV3y = 69
            };

            
            var calc = new CalculateCoordinates(service.Object);

            Assert.Throws<Exception>(() => calc.getLocation(request));
        }

    }
}
