using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PortfolioModel.Abstract;
using Project_Portfolio.Controllers;

namespace UnitTests
{
    [TestFixture]
    public abstract class MotherTestClass
    {
        protected Mock<IProjectRepository> ProjectRepository { get; set; }
        protected Mock<IProfileRepository> ProfileRepository { get; set; }

        
        [SetUp]
        public virtual void Setup()
        {
            ProfileRepository = new Mock<IProfileRepository>();
            ProjectRepository = new Mock<IProjectRepository>();
        }
        

    }
}
