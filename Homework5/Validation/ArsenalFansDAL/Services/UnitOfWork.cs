using ArsenalFansDAL.Contexts;
using ArsenalFansDAL.Contracts.Exceptions;
using ArsenalFansDAL.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace ArsenalFansDAL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArsenalDbContext _context;
        private IDbContextTransaction? _currentTransaction;

        public UnitOfWork(ArsenalDbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            lock (_context)
            {
                if (_currentTransaction != null)
                {
                    throw new UnitOfWorkAlreadyInTransactionStateException();
                }

                _currentTransaction = _context.Database.BeginTransaction();
            }
            return _currentTransaction;
        }

        IRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
        {
            return new Repository<TEntity>(_context.Set<TEntity>());
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
