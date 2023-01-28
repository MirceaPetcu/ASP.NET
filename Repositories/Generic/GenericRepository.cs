using Microsoft.EntityFrameworkCore;
using ProiectV1.Data;

namespace ProiectV1.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ProiectContext context;
        protected readonly DbSet<TEntity> table;

        public GenericRepository(ProiectContext context)
        {
            this.context = context;
            this.table = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            table.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await table.AddRangeAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            table.RemoveRange(entities);
        }

        public List<TEntity> GetAll()
        {
            var entities = table.AsNoTracking().ToList();
            return entities;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var entities = await table.AsNoTracking().ToListAsync();
            return entities;
        }

        public TEntity GetById(Guid id)
        {
            return table.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await table.FindAsync(id);
        }

        public bool Save()
        {
            if (context.SaveChanges()> 0)
                return true;
            return false;
        }

        public async Task<bool> SaveAsync()
        {
            if (await context.SaveChangesAsync() > 0)
                return true;
            return false;
        }

        public void Update(TEntity entity)
        {
            table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            table.UpdateRange(entities);
        }

      
    }
}
