using System.Linq;

namespace PortfolioModel.Abstract
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetMany();
        TEntity GetEntity(int id);
        TEntity AddOrUpdate(TEntity entity);
        void Delete(int entityID);
        void Save();
    }
}
