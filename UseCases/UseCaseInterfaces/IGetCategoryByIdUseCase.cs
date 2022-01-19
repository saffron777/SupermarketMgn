using CoreBussines;

namespace UseCases
{
    public interface IGetCategoryByIdUseCase
    {
       public Category Execute(int categoryId);
    }
}