using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Library;

public interface IRepository<T,TKeyType> 
where T : class
where TKeyType : IComparable
{
    IQueryable<T> GetAll();
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(TKeyType id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}

public class Repository<T,TKeyType> : IRepository<T,TKeyType> 
where T : class
where TKeyType : IComparable
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public async Task<T> GetByIdAsync(TKeyType id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
