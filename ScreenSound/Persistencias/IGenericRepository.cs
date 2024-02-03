using ScreenSound.Modelos;

namespace ScreenSound.Persistencias;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(int id);
    TEntity? GetBy(Func<TEntity, bool> predicate);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
}