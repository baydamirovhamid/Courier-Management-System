using Microsoft.EntityFrameworkCore.Storage;
using reserva.user.backend.Models;
using System.Linq.Expressions;

namespace reserva.user.backend.Infrastructure.Repository
{
    public interface IRepository<TEnity> where TEnity : class
    {
        IEnumerable<TEnity> All { get; }
        IQueryable<TEnity> AllQuery { get; }
        void Insert(TEnity entity);
        void Update(TEnity entity);
        void Remove(TEnity entity);
        IQueryable<TEnity> FindBy(Expression<Func<TEnity, bool>> predicate);
        Task<IEnumerable<TEnity>> AllAsync();
        Task<int> SaveAsync();
        void Save();
        Task<IDbContextTransaction> BeginTransactionAsync();
        IDbContextTransaction BeginTransaction();
        //IDbContextTransaction UseTransaction(IDbContextTransaction transaction);
        void CommitTransaction(IDbContextTransaction transaction);
        void RollBackTransaction(IDbContextTransaction transaction);
        void Update(STADIUM reserve);
    }
}
