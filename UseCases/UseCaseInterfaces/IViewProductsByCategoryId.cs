using CoreBussines;

namespace UseCases
{
    public interface IViewProductsByCategoryId
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}