using CalculatingArea.Models;

namespace CalculatingArea.Inteinterfaces
{
    public interface ICalculatingAreaService<T> where T : Figure
    {
       T CalculateArea(T figure);
    }
}
