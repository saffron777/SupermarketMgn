using CoreBussines;

namespace UseCases
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();
    }
}