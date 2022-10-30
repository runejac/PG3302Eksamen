namespace A_Team.Core.Interfaces;

public interface IRepository<TEntity> where TEntity : class {
    TEntity GetById(int id);
    IEnumerable<TEntity> GetAll();

    void Insert(TEntity entity);
    void Remove(TEntity entity);
}