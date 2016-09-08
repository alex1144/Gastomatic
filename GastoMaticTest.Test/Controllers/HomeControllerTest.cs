using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GastoMatic;
using GastoMatic.Controllers;

namespace GastoMaticTest.Test.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HControllerIndex()
        {
            HomeController controller= new HomeController();
            ViewResult result = (ViewResult)controller.Index(); //as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
