using Microsoft.EntityFrameworkCore.Storage;
using ArsenalFansModel.Contracts.Interfaces;

namespace ArsenalFansDAL.Contracts.Interfaces
{
    public interface IUnitOfWork
    {
        IDbContextTransaction BeginTransaction();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        Task<int> SaveChangesAsync();
    }
}
