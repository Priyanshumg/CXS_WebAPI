using Infrastructure.Data;
using Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Class;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public void Update(T entity) => _dbSet.Update(entity);
    public void Delete(T entity) => _dbSet.Remove(entity);
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}

// public class GenericRepository<T> : IGenericRepository<T> where T : class
// {
//     private readonly AppDbContext _context;
//     private readonly DbSet<T> _dbSet;
//
//     // ✅ Only inject the context — not DbSet<T>
//     public GenericRepository(AppDbContext context)
//     {
//         _context = context;
//         _dbSet = _context.Set<T>(); // this fetches the DbSet automatically
//     }
//
//     public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
//
//     public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
//
//     public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
//
//     public void Update(T entity) => _dbSet.Update(entity);
//
//     public void Delete(T entity) => _dbSet.Remove(entity);
//
//     public async Task SaveAsync() => await _context.SaveChangesAsync();
// }
