using Xunit;
using FluentAssertions;
using CalculatingArea.Inteinterfaces;
using CalculatingArea.Services;
using CalculatingArea.Models;
using CalculatingArea.Models.Enums;
using CalculatingArea.Exceptions;

namespace Tests.CalculatingAreaServiceTests
{
    public class CalculatingAreaServiceTests
    {
        private static ICalculatingAreaService<Figure> GetService()
        {
            return new CalculatingAreaService<Figure>();
        }

        public static IEnumerable<object[]> TypeOfFigure =>
           new List<object[]>
           {
                new object[]
                {
                    new Triangle()
                {
                    SideA = 5,
                    SideB = 6,
                    SideC = 7
                },
                    14.6969

           },
                new object[]
                {
                    new Circle()
                {
                    Radius = 5
                },
                    78.5398
                }

           };


        private readonly static Triangle _incorrectTriangle = new()
        {
            SideA = 5,
            SideB = 8,
            SideC = 1
        };

        public static IEnumerable<object[]> TypeOfTriangle =>
           new List<object[]>
           {
                new object[]
                {
                    new Triangle()
                {
                    SideA = 5,
                    SideB = 6,
                    SideC = 7
                },
                    TypeTriangle.Unknown

           },
                new object[]
                {
                    new Triangle()
                {
                    SideA = 3,
                    SideB = 4,
                    SideC = 5
                },
                    TypeTriangle.Rectangular
                }

           };

        [Theory]
        [MemberData(nameof(TypeOfFigure))]
        public void CalculateArea_ExpectedResult(Figure figure, double area)
        {
            var calculatingService = GetService();

            calculatingService.CalculateArea(figure);
            figure.Area.Should().Be(area);
        }


        [Theory]
        [MemberData(nameof(TypeOfTriangle))]
        public void CalculateArea_TypeCorrectTriangle_ExpectedResult(Triangle triangle, TypeTriangle typeTriangle)
        {
            var calculatingService = GetService();

            calculatingService.CalculateArea(triangle);
            triangle.TypeTriangle.Should().Be(typeTriangle);
        }

        [Fact]
        public void CalculateArea_IncorrectTriangle_()
        {
            var calculatingService = GetService();
            Assert.Throws<IncorrectTriangleException>(() => calculatingService.CalculateArea(_incorrectTriangle));
        }
    }
}