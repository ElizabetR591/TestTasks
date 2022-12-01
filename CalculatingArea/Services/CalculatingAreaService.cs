using CalculatingArea.Exceptions;
using CalculatingArea.Inteinterfaces;
using CalculatingArea.Models;
using CalculatingArea.Models.Enums;
using System;

namespace CalculatingArea.Services
{
    public class CalculatingAreaService<T> : ICalculatingAreaService<T>  where T : Figure
    {
        public T CalculateArea(T figure)
        {
            switch (figure)
            {
                case Triangle triangle:

                    CalculateTriangleArea(triangle);
                    if (triangle.TypeTriangle == TypeTriangle.Incorrect)
                    {
                        throw new IncorrectTriangleException(triangle.SideA, triangle.SideB, triangle.SideC);
                    }
                    break;

                case Circle circle:
                    circle.Area = Math.Round(Math.PI * Math.Pow(circle.Radius, 2), 4);
                    break;
            }
            return figure;
        }

        private Triangle CalculateTriangleArea(Triangle triangle)
        {
            /*Так как в задаче не указано, кому и зачем может понадобиться информация о типе, считаю целесообразным записать его в соответсвующее поле. 
              Тип треугольника может повлиять на выбор формулы вычисления площали, но т.к. в задании указано требование вычисления площади по трём сторонам, 
              не считаю правильным использовать другую формулы без обсуждений с лицом, сформировавшим задачу. */
            
            triangle.TypeTriangle = GetTypeTriangle(triangle);
            var p = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;
            triangle.Area = Math.Round(Math.Sqrt(p * (p - triangle.SideA) * (p - triangle.SideB) * (p - triangle.SideC)), 4);
           
            return triangle;
        }

        private TypeTriangle GetTypeTriangle(Triangle triangle)
        {
            if ((triangle.SideC + triangle.SideB <= triangle.SideA) || (triangle.SideA + triangle.SideB <= triangle.SideC) || (triangle.SideA + triangle.SideC <= triangle.SideB))
            {
                return TypeTriangle.Incorrect;
            }

            var squaredA = Math.Pow(triangle.SideA, 2);
            var squaredB = Math.Pow(triangle.SideB, 2);
            var squaredC = Math.Pow(triangle.SideC, 2);

            if ((squaredA + squaredB == squaredC) || (squaredB + squaredC == squaredA) || (squaredA + squaredC == squaredB))
            {
                return TypeTriangle.Rectangular;
            }

            return TypeTriangle.Unknown;
        }
    }
}
