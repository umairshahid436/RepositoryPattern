using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TariffComparison.Data.Interface;

namespace TariffComparison.Data.Repository
{
    public class GenericRespository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private IDbContext dbContext;
        private DbSet<TEntity> dbSet;
        public DbSet<TEntity> DbSet
        {
            get => dbSet ?? (dbSet = DbContext.Set<TEntity>());
            set => dbSet = value;
        }
        public IDbContext DbContext
        {
            get { return dbContext; }
            private set { dbContext = value; }
        }

        public GenericRespository(IDbContext dbContext)
        {
            this.DbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> Get()
        {
            return await dbSet.ToListAsync();
        }

        public virtual Task<TEntity> Add(TEntity entity)
        {
            return Task.FromResult(dbSet.Add(entity).Entity);
        }
    }
}
