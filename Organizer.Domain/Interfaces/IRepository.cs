using System;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetByIdAsync(int id);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id, string lang);
        TEntity GetById(int id, string lang);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        void Remove(int id, string lang);
        int SaveChanges();
    }
}