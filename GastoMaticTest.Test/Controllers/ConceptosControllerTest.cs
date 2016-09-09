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
    public class ConceptosControllerTest
    {
        //[TestMethod()]
        //public void ConceptosControllerConstructorTest()
        //{
        //    ConceptosController target = new ConceptosController();
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}
        [TestMethod]
        public void CConceptosIndexTest()
        {
            ConceptosController target = new ConceptosController(); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Index();
            // Assert
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void CConceptosIndexTestFail()
        {
            ConceptosController target = new ConceptosController(); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Index();
            Assert.AreNotEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        [TestMethod]
        public void CConceptosCreateTestFail()
        {
            ConceptosController target = new ConceptosController(); // TODO: Initialize to an appropriate value
            FormCollection collection= new FormCollection();
            collection.Add("Nombre","Automatic");
            collection.Add("Descripcion","Automatic");
            ActionResult actual;
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            actual = target.Create(collection);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
