﻿
namespace UseCases
{
    public interface IDeleteProductUseCase
    {
        Task Execute(int productId);
    }
}