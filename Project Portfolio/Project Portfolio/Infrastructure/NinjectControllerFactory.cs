using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using PortfolioModel.Abstract;
using PortfolioModel.Concrete;
using PortfolioModel.Entities;

namespace Project_Portfolio.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IProjectRepository>().To<ProjectRepository>();
            
            //MockBindings();
        }

        private void MockBindings()
        {
            Mock<IProjectRepository> mock = new Mock<IProjectRepository>();
            mock.Setup(m => m.GetMany()).Returns(new List<Project>
            {
                new Project
                {
                    ID = 1,
                    Name = "Project 1",
                    Description = "Description 1",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = true,
                },
                new Project
                {
                    ID = 2,
                    Name = "Project 2",
                    Description = "Description 2",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = true,
                },
                new Project
                {
                    ID = 3,
                    Name = "Project 3",
                    Description = "Description 3",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = true,
                },
                new Project
                {
                    ID = 4,
                    Name = "Project 4",
                    Description = "Description 4",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
                new Project
                {
                    ID = 5,
                    Name = "Project 5",
                    Description = "Description 5",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
                new Project
                {
                    ID = 6,
                    Name = "Project 6",
                    Description = "Description 6",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
                new Project
                {
                    ID = 7,
                    Name = "Project 7",
                    Description = "Description 7",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },new Project
                {
                    ID = 1,
                    Name = "Project 1",
                    Description = "Description 1",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = true,
                },
                new Project
                {
                    ID = 2,
                    Name = "Project 2",
                    Description = "Description 2",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = true,
                },
                new Project
                {
                    ID = 3,
                    Name = "Project 3",
                    Description = "Description 3",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = true,
                },
                new Project
                {
                    ID = 4,
                    Name = "Project 4",
                    Description = "Description 4",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
                new Project
                {
                    ID = 5,
                    Name = "Project 5",
                    Description = "Description 5",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
                new Project
                {
                    ID = 6,
                    Name = "Project 6",
                    Description = "Description 6",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
                new Project
                {
                    ID = 7,
                    Name = "Project 7",
                    Description = "Description 7",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },new Project
                {
                    ID = 1,
                    Name = "Project 1",
                    Description = "Description 1",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = true,
                },
                new Project
                {
                    ID = 2,
                    Name = "Project 2",
                    Description = "Description 2",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = true,
                },
                new Project
                {
                    ID = 3,
                    Name = "Project 3",
                    Description = "Description 3",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = true,
                },
                new Project
                {
                    ID = 4,
                    Name = "Project 4",
                    Description = "Description 4",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
                new Project
                {
                    ID = 5,
                    Name = "Project 5",
                    Description = "Description 5",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
                new Project
                {
                    ID = 6,
                    Name = "Project 6",
                    Description = "Description 6",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
                new Project
                {
                    ID = 7,
                    Name = "Project 7",
                    Description = "Description 7",
                    SourceUrl = "http://github.com",
                    DemoUrl = "http://stellanoxsolutions.com",
                    Featured = false,
                },
            }.AsQueryable());
            _ninjectKernel.Bind<IProjectRepository>().ToConstant((mock.Object));
        }
    }
}