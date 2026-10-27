using System.Collections;
using Lab08_MaxiFranco.Models;

namespace Lab08_MaxiFranco.Repositories.Implementaciones;

public class UnitOfWork : IUnitOfWork
{
    private readonly Hashtable _repositories;
    private readonly Lab08DbContext _context;

    public UnitOfWork(Lab08DbContext context)
    {
        _context = context;
        _repositories = new Hashtable();
    }

    public Task<int> Complete()
    {
        return _context.SaveChangesAsync();
    }

    public IGenericRepository<TEntity> Repository<TEntity>()
        where TEntity : class
    {
        var type = typeof(TEntity).Name;

        if (_repositories.ContainsKey(type))
        {
            return (IGenericRepository<TEntity>)_repositories[type]!;
        }

        var repositoryType = typeof(GenericRepository<>);

        var repositoryInstance = Activator.CreateInstance(
            repositoryType.MakeGenericType(typeof(TEntity)),
            _context);

        if (repositoryInstance != null)
        {
            _repositories.Add(type, repositoryInstance);

            return (IGenericRepository<TEntity>)repositoryInstance;
        }

        throw new Exception(
            $"Could not create repository instance for type {type}");
    }
}