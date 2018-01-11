using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioModel.Abstract
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetMany();
        TEntity GetEntity(int id);
        TEntity AddOrUpdate(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
