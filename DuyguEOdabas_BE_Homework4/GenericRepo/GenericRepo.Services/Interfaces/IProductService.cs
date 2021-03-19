
using GenericRepo.Domain.Entities;
using GenericRepo.Domain.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepo.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetProducts();

        Task<ProductResponse> GetProduct(Expression<Func<Product, bool>> expression);
        Task<ProductResponse> GetProduct(int id);

    }
}