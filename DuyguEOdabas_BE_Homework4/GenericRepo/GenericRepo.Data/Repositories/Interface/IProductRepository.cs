using GenericRepo.Data.Repositories.Core;
using GenericRepo.Domain.Entities;
using System.Threading.Tasks;

namespace GenericRepo.Data.Repositories.Interface
{
    public interface IProductRepository : IReadRepository<Product>, IWriteRepository<Product>
    {
        Task<bool> IsExistsProduct(string name);
    }
}