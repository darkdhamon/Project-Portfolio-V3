using System;
using System.Data.Entity.Migrations;
using System.Linq;
using PortfolioModel.Abstract;
using PortfolioModel.Entities;

namespace PortfolioModel.Concrete
{
    public class ProjectRepository:AbstractRepository<Project>, IProjectRepository
    {
        public override IQueryable<Project> GetMany()
        {
            return Context.Projects;
        }

        public override Project GetEntity(int id)
        {
            return Context.Projects.FirstOrDefault(p => p.ID == id);
        }

        public override Project AddOrUpdate(Project entity)
        {
            entity.Updated = DateTime.Now;
            Context.Projects.AddOrUpdate(entity);
            Save();
            return entity;
        }

        public override void Delete(int entityID)
        {
            
            Context.Projects.Remove(GetEntity(entityID));
            Save();
        }
    }

    public class ProfileRepository : AbstractRepository<Profile>, IProfileRepository
    {
        public override IQueryable<Profile> GetMany()
        {
            return Context.Profiles;
        }

        public override Profile GetEntity(int id)
        {
            return Context.Profiles.FirstOrDefault(p => p.ID == id);
        }

        public override Profile AddOrUpdate(Profile entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int entityID)
        {
            throw new NotImplementedException();
        }
    }
}