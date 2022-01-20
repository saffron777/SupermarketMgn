namespace UseCases
{
    public interface IRecordTransacctionUseCase
    {
        void Execute(string cashierName, int productId,  int soldQty);
    }
}