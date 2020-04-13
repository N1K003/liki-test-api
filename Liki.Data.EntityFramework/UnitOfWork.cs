using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Liki.Data.Contracts.Abstractions;

namespace Liki.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _context;

        public UnitOfWork(ApiDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get<T>() where T : class, IBaseEntity
        {
            return _context.Set<T>();
        }

        public T Create<T>(T item) where T : class, IBaseEntity
        {
            return _context.Set<T>().Add(item).Entity;
        }

        public T Delete<T>(T item) where T : class, IBaseEntity
        {
            return _context.Set<T>().Remove(item).Entity;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}