using GenericRepo.Data.Repositories.Interface;
using GenericRepo.Domain.Entities;
using GenericRepo.Domain.Response.Product;
using GenericRepo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepo.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> GetProduct(int id)
        {
            var result = await _productRepository.GetById(id);

            return new ProductResponse
            {
                Id = result.Id,
                Name = result.Name,
                Price = result.Price,
            };
        }

        public async Task<ProductResponse> GetProduct(Expression<Func<Product, bool>> expression)
        {
            var result = await _productRepository.Get(expression);


            return new ProductResponse
            {
                Id = result.Id,
                Name = result.Name,
                Price = result.Price,
            };
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var result = await _productRepository.GetAll();

            return result.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            }).ToList();
        }

    }
}