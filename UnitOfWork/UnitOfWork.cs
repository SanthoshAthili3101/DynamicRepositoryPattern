using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using DynamicRepositoryPattern.GenericDbContext;

namespace DynamicRepositoryPattern.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : class
    {
        private readonly TContext _context;
        private Hashtable _repositories;
        private readonly IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public IEfRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(EfRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IEfRepository<TEntity>)_repositories[type];
        }

    }
}
