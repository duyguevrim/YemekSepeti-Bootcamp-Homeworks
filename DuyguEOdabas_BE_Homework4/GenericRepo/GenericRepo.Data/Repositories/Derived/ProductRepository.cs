using GenericRepo.Data.Repositories.Core;
using GenericRepo.Data.Repositories.Interface;
using GenericRepo.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepo.Data.Repositories.Derived
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public async Task<bool> IsExistsProduct(string name)
        {
            var sql = $"Select Count(*) as TotalCount From Product where Name = '{name}'";

            var result = await base.ExecSqlQuery(sql, async (reader) =>
            {
                int totalCount = 0;
                if (await reader.ReadAsync())
                    totalCount = reader.GetInt32(reader.GetOrdinal("TotalCount"));

                return totalCount > 0;
            })?.FirstOrDefault();
            return result;
        }
    }
}