using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PortfolioModel.Entities;
using Project_Portfolio.Controllers;
using Project_Portfolio.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests
{
    [TestFixture]
    public class ProjectControllerTest : MotherTestClass
    {
        public ProjectController Controller { get; set; }
        public List<Project> Projects { get; set; }

        public override void Setup()
        {
            base.Setup();
            Controller = new ProjectController(ProjectRepository.Object);
            Projects = new List<Project>
            {
                new Project()
                {
                    DemoUrl = "http://demo.com/1",
                    Description = "Description 1",
                    Featured = true,
                    ID = 1,
                    Name = "Test Project 1",
                    SourceUrl = "http://source.com/1",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/2",
                    Description = "Description 2",
                    Featured = true,
                    ID = 2,
                    Name = "Test Project 2",
                    SourceUrl = "http://source.com/2",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/3",
                    Description = "Description 3",
                    Featured = false,
                    ID = 3,
                    Name = "Test Project 3",
                    SourceUrl = "http://source.com/3",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/1",
                    Description = "Description 1",
                    Featured = true,
                    ID = 4,
                    Name = "Test Project 1",
                    SourceUrl = "http://source.com/1",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/2",
                    Description = "Description 2",
                    Featured = false,
                    ID = 5,
                    Name = "Test Project 2",
                    SourceUrl = "http://source.com/2",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/3",
                    Description = "Description 3",
                    Featured = false,
                    ID = 6,
                    Name = "Test Project 3",
                    SourceUrl = "http://source.com/3",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/1",
                    Description = "Description 1",
                    Featured = true,
                    ID = 7,
                    Name = "Test Project 1",
                    SourceUrl = "http://source.com/1",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/2",
                    Description = "Description 2",
                    Featured = false,
                    ID = 8,
                    Name = "Test Project 2",
                    SourceUrl = "http://source.com/2",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/3",
                    Description = "Description 3",
                    Featured = false,
                    ID = 9,
                    Name = "Test Project 3",
                    SourceUrl = "http://source.com/3",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/1",
                    Description = "Description 1",
                    Featured = false,
                    ID = 10,
                    Name = "Test Project 1",
                    SourceUrl = "http://source.com/1",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/2",
                    Description = "Description 2",
                    Featured = false,
                    ID = 11,
                    Name = "Test Project 2",
                    SourceUrl = "http://source.com/2",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/3",
                    Description = "Description 3",
                    Featured = false,
                    ID = 12,
                    Name = "Test Project 3",
                    SourceUrl = "http://source.com/3",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/1",
                    Description = "Description 1",
                    Featured = false,
                    ID = 13,
                    Name = "Test Project 1",
                    SourceUrl = "http://source.com/1",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/2",
                    Description = "Description 2",
                    Featured = false,
                    ID = 14,
                    Name = "Test Project 2",
                    SourceUrl = "http://source.com/2",
                    Updated = DateTime.Now
                },
                new Project()
                {
                    DemoUrl = "http://demo.com/3",
                    Description = "Description 3",
                    Featured = false,
                    ID = 15,
                    Name = "Test Project 3",
                    SourceUrl = "http://source.com/3",
                    Updated = DateTime.Now
                }
            };
            ProjectRepository.Setup(repo => repo.GetMany()).Returns(new EnumerableQuery<Project>(Projects));
            for (int i = 0; i < Projects.Count; i++)
            {
                ProjectRepository.Setup(repo => repo.GetEntity(i)).Returns(Projects.Find(p => p.ID == i));
            }
            ProjectRepository.Setup(repo=>repo.AddOrUpdate(It.Is<Project>(p=>p.ID==0))).Returns()
        }

        [TestCase()]
        public void IndexTest()
        {
            //No Input Test
            var result = Controller.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult) result;
            var viewModel = viewResult.Model;
            Assert.IsInstanceOfType(viewModel, typeof(ProjectListViewModel));
            var projectListVm = (ProjectListViewModel) viewModel;
            Assert.AreEqual(projectListVm.PageSize, 6);
            Assert.AreEqual(projectListVm.Projects.Count, 6);
            Assert.AreEqual(projectListVm.CurrentPage, 1);
            Assert.AreEqual(projectListVm.NumPages, 3);

            //Page Number Test
            result = Controller.Index(page: 2);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            viewResult = (ViewResult) result;
            viewModel = viewResult.Model;
            Assert.IsInstanceOfType(viewModel, typeof(ProjectListViewModel));
            projectListVm = (ProjectListViewModel) viewModel;
            Assert.AreEqual(projectListVm.PageSize, 6);
            Assert.AreEqual(projectListVm.Projects.Count, 6);
            Assert.AreEqual(projectListVm.CurrentPage, 2);
            Assert.AreEqual(projectListVm.NumPages, 3);

            //Page Size Test
            result = Controller.Index(pageSize: 12);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            viewResult = (ViewResult) result;
            viewModel = viewResult.Model;
            Assert.IsInstanceOfType(viewModel, typeof(ProjectListViewModel));
            projectListVm = (ProjectListViewModel) viewModel;
            Assert.AreEqual(projectListVm.PageSize, 12);
            Assert.AreEqual(projectListVm.Projects.Count, 12);
            Assert.AreEqual(projectListVm.CurrentPage, 1);
            Assert.AreEqual(projectListVm.NumPages, 2);

            //Negative Page Number and Size Test
            result = Controller.Index(page: -2, pageSize: -1);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            viewResult = (ViewResult) result;
            viewModel = viewResult.Model;
            Assert.IsInstanceOfType(viewModel, typeof(ProjectListViewModel));
            projectListVm = (ProjectListViewModel) viewModel;
            Assert.AreEqual(projectListVm.PageSize, 6);
            Assert.AreEqual(projectListVm.Projects.Count, 6);
            Assert.AreEqual(projectListVm.CurrentPage, 1);
            Assert.AreEqual(projectListVm.NumPages, 3);
        }

        [TestCase()]
        public void FeaturedTest()
        {
            // 4
            var result = Controller.FeaturedProjects();
            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
            var viewResult = (PartialViewResult) result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(ProjectListViewModel));
            var viewModel = (ProjectListViewModel) viewResult.Model;
            foreach (var viewModelProject in viewModel.Projects)
            {
                Assert.IsTrue(viewModelProject.Featured);
            }
            
        }

        [TestCase()]
        public void DeleteTest()
        {
            var result = Controller.Delete(1);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestCase()]
        public void EditGetTest()
        {
            // Set up New Project
            var result = Controller.Edit(id: null);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult) result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(Project));
            var viewModel = (Project) viewResult.Model;
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Name));
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.Description));
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.DemoUrl));
            Assert.IsTrue(string.IsNullOrEmpty(viewModel.SourceUrl));
            Assert.IsFalse(viewModel.Featured);
            Assert.IsTrue(new DateTime().Equals(viewModel.Updated));
            Assert.AreEqual(viewModel.ID, 0);

            // Get existing project at random
            var projectID = new Random().Next(1, Projects.Count);
            var projectCompare = Projects.FirstOrDefault(p => p.ID == projectID);
            result = Controller.Edit(projectID);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            viewResult = (ViewResult) result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(Project));
            viewModel = (Project) viewResult.Model;
            Assert.AreEqual(viewModel.ID, projectCompare.ID);
            Assert.AreEqual(viewModel.DemoUrl, projectCompare.DemoUrl);
            Assert.AreEqual(viewModel.Description, projectCompare.Description);
            Assert.AreEqual(viewModel.Featured, projectCompare.Featured);
            Assert.AreEqual(viewModel.Name, projectCompare.Name);
            Assert.AreEqual(viewModel.SourceUrl, projectCompare.SourceUrl);
            Assert.AreEqual(viewModel.Updated, projectCompare.Updated);
        }

        [TestCase()]
        public void EditPostTest()
        {
            var submittedProject = new Project
            {
                ID = 0,
                Featured = false,
                DemoUrl = "github.com",
                SourceUrl = "google.com",
                Description = "Blah",
                Name = "Test"
            };
            var result = Controller.Edit(submittedProject);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult) result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(Project));
            var viewModel = (Project) viewResult.Model;
            
        }
    }
}