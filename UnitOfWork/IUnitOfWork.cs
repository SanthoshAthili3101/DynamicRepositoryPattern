using DynamicRepositoryPattern.GenericDbContext;
using System.Security.Principal;

namespace DynamicRepositoryPattern.UnitOfWork
{
    public interface IUnitOfWork 
    {
        IEfRepository<T> Repository<T>() where T : class;
    }
}
