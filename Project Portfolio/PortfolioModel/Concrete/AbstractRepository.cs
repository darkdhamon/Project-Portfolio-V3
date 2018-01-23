using System.Data.Entity;
using System.Linq;
using PortfolioModel.Abstract;
using PortfolioModel.Entities;

namespace PortfolioModel.Concrete
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(string connection = "DefaultConnection") : base(connection)
        {
        }

        public DbSet<Project> Projects { get; set; }
    }

    public abstract class AbstractRepository<TEntity>:IRepository<TEntity>
    {
        protected  ProjectContext Context = new ProjectContext();


        public abstract IQueryable<TEntity> GetMany();
        public abstract TEntity GetEntity(int id);
        public abstract TEntity AddOrUpdate(TEntity entity);
        public abstract void Delete(int entityID);

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
