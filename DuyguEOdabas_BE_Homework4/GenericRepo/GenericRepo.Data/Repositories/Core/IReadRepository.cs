using GenericRepo.Domain.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepo.Data.Repositories.Core
{
    public interface IReadRepository<T> where T : IEntity
    {
        Task<T> GetById(int id);

        Task<T> Get(Expression<Func<T, bool>> expression);

        Task<IQueryable<T>> GetAll();

        Task<IQueryable<T>> GetMany(Expression<Func<T, bool>> expression);
    }
}