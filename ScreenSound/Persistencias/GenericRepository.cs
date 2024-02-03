using ScreenSound.Modelos;

namespace ScreenSound.Persistencias;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ScreenSoundContext _context;

    public GenericRepository(ScreenSoundContext context)
    {
        _context = context;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public virtual TEntity? GetById(int id)
    {
        return _context.Set<TEntity>().SingleOrDefault(a => a.Id == id);
    }

    public TEntity? GetBy(Func<TEntity, bool> predicate)
    {
        return _context.Set<TEntity>().SingleOrDefault(predicate);
    }

    public virtual void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        SaveChanges();
    }

    public virtual void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        SaveChanges();
    }      

    public virtual void Delete(int id)
    {
        var artist = GetById(id);

        if (artist is null)
            return;

        _context.Set<TEntity>().Remove(artist);
        SaveChanges();
    }

    protected virtual void SaveChanges()
    {
        _context.SaveChanges();
    }        
}