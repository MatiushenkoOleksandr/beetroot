using Servis.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository.Abstracts
{
    public interface IRepository<TKey, TEntity>
     where TEntity : IEntity<TKey>
    {
        Task Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task<TEntity> Get(TKey key);
        Task<IEnumerable<TEntity>> GetRange(IEnumerable<TKey> keys);
        Task<IEnumerable<TEntity>> GetAll();
        Task Delete(TKey id);
        Task Update(TEntity entity);
        //  ..., Update, Delete methods
    }
}
