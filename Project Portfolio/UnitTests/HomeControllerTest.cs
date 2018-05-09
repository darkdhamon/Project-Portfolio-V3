using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Project_Portfolio.Controllers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests
{
    [TestFixture]
    public class HomeControllerTest:MotherTestClass
    {
        public HomeController Controller { get; set; }

        
        public override void Setup()
        {
            Controller=new HomeController();
        }

        [TestCase()]
        public void IndexTest()
        {
            var result = Controller.Index();
            Assert.IsInstanceOfType(result,typeof(ViewResult));
        }
    }
}
