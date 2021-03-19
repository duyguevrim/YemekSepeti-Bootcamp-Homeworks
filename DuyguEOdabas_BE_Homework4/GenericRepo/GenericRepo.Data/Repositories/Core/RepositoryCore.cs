using GenericRepo.Data.Context;
using GenericRepo.Domain.CustomExceptions;
using GenericRepo.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace GenericRepo.Data.Repositories.Core
{
    public abstract class RepositoryCore<T> where T : class, IEntity
    {
        protected readonly DbContext _dbContext = null;
        protected readonly DbSet<T> _dbSet = null;

        public RepositoryCore(BrandContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        protected virtual List<T> ExecSqlQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using var command = _dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;

            if (command.Connection.State != System.Data.ConnectionState.Open)
                command.Connection.Open();

            var entities = new List<T>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                entities.Add(map(reader));
            }

            return entities;
        }

        public async virtual Task<int> SaveChanges()
        {
            int saveChangeResult = 0;
            try
            {
                // validation

                saveChangeResult = await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                HandleDbException(ex);
            }

            return saveChangeResult;
        }

        public virtual void HandleDbException(Exception ex)
        {
            if (ex is DbUpdateConcurrencyException concurrencyException)
            {
                // handle exception
                throw new ConcurrencyException();
            }
            else if (ex is DbUpdateException updateEx)
            {
                if (updateEx.InnerException != null && updateEx.InnerException.InnerException != null)
                {
                    if (updateEx.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // unique KeyException
                            case 547: // check constraints
                            case 2601: // duplicate
                                throw new ConcurrencyException();
                            default:
                                throw new DatabaseAccessException(updateEx.Message, updateEx.InnerException);
                        }
                    }
                }

                throw new DatabaseAccessException(updateEx.Message, updateEx.InnerException);
            }
        }
    }
}