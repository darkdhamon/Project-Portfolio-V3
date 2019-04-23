using PortfolioModel.Entities;

namespace PortfolioModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PortfolioModel.Concrete.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PortfolioModel.Concrete.ProjectContext";
        }

        protected override void Seed(PortfolioModel.Concrete.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Projects.AddOrUpdate(new Project
            {
                Name = "Project Portfolio V3",
                Description = "This project is the third iteration of my project portfolio. It is a " +
                              "a data driven MVC 5 project backed by SQL Server.",
                Featured = true,
                SourceUrl = "http://Github.com/darkdhamon/project-portfolio-V3",
                ID = 1,
                Updated = DateTime.Now,
                DemoUrl = "http://www.bronzeharoldbrown.com"
            });
            context.Profiles.AddOrUpdate(new Profile
            {
                ID = 1,
                DateOfBirth = new DateTime(1990, 2, 22),
                FirstName = "Bronze",
                LastName = "Brown",
                MiddleName = "Harold",
                
            });
        }
    }
}
