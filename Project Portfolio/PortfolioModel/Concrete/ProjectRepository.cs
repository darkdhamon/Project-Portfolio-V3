using System;
using System.Data.Entity;
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

        public override void Delete(Project entity)
        {
            
            Context.Projects.Remove(GetEntity(entity.ID));
            Save();
        }
    }
}