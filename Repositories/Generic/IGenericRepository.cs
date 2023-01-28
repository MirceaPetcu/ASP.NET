namespace ProiectV1.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //create
        Task CreateAsync(TEntity entity);
        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        //get
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();

        //get by id
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);

        //update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //save
        bool Save();
        Task<bool> SaveAsync();


        

        
    }
}
