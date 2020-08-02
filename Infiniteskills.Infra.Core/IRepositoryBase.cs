using System;
using System.Collections.Generic;
using System.Text;

namespace Infiniteskills.Infra.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id);
        TEntity SearchFor(Dictionary<string, object> parametersList);
        List<TEntity> SearchFor(Dictionary<string, object> parametersList, int pageCount, string orderBy);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}
