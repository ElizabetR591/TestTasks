using CalculatingArea.Models.Enums;

namespace CalculatingArea.Models
{
    public class Triangle : Figure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public TypeTriangle TypeTriangle { get; set; } = TypeTriangle.Unknown;
    }
}
