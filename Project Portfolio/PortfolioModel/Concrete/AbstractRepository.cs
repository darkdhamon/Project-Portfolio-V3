using System.Data.Entity;
using System.Linq;
using PortfolioModel.Abstract;
using PortfolioModel.Entities;

namespace PortfolioModel.Concrete
{
    public class ProjectContext : DbContext
    {
        public const string defaultConnection = "DefaultConnection";
        public ProjectContext(string connection = defaultConnection) : base(connection)
        {
        }

        public ProjectContext() : base(defaultConnection)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Profile> Profiles { get; set; }
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
