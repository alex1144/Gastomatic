using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GastoMatic;
using GastoMatic.Models;

namespace GastoMaticTest.Test.Models
{
    [TestClass]
    public class ConceptosServiceModelTest
    {
        //Pruebas de modelo
        [TestMethod()]
        public void SConceptosGetCuentaGastosInstanciaTest()
        {
            ConceptosServiceModel target = new ConceptosServiceModel(); // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            target.IdConcepto = 1;
            actual = target.GetCuentaGastosConceptos();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        //Pruebas de modelo
        [TestMethod()]
        public void SConceptosGetCuentaGastosValueTest()
        {
            ConceptosServiceModel target = new ConceptosServiceModel(); // TODO: Initialize to an appropriate value
            bool actual;
            target.IdConcepto = 1;
            actual = target.GetCuentaGastosConceptos();
            Assert.AreNotEqual(string.Empty, target.Nombre, true);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        [TestMethod()]
        public void SConceptosCreaConcepto() {
            ConceptosServiceModel target = new ConceptosServiceModel(); // TODO: Initialize to an appropriate value
            bool actual;
            target.Nombre="Pruebas";
            target.Descripcion = "Esto es una cuenta de pruebas";
            actual = target.CreaConcepto();
            Assert.IsTrue(actual);
        }
        [TestMethod()]
        public void SConceptosActualizaConcepto()
        {
            ConceptosServiceModel target = new ConceptosServiceModel(); // TODO: Initialize to an appropriate value
            bool actual;
            target.IdConcepto = 7;
            target.Nombre = "Pruebas";
            target.Descripcion = "Esto es una cuenta de pruebas modificada";
            actual = target.ActualizaConcepto();
            Assert.IsTrue(actual);
        }
        [TestMethod()]
        public void SConceptosBorraConcepto()
        {
            ConceptosServiceModel target = new ConceptosServiceModel(); // TODO: Initialize to an appropriate value
            bool actual;
            target.IdConcepto = 14;
            actual = target.BorraConcepto();
            Assert.IsTrue(actual);
        }
    }
}
