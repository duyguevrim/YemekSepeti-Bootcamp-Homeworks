using GenericRepo.Data.Context;
using GenericRepo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepo.Data.Repositories.Core
{
    public class ReadOnlyRepositoryBase<T> : RepositoryCore<T>, IReadRepository<T>
        where T : class, IEntity
    {
        public ReadOnlyRepositoryBase() : base(new BrandContext())
        {
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FindAsync(expression);
        }

        public async Task<IQueryable<T>> GetAll()
        {
            // ??
            IEnumerable<T> result = await _dbSet.ToListAsync();
            return result.AsQueryable();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IQueryable<T>> GetMany(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> result = await _dbSet.Where(expression).ToListAsync();
            return result.AsQueryable();
        }
    }
}