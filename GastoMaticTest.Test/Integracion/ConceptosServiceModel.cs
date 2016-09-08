using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GastoMatic;
using GastoMatic.Models;

namespace GastoMaticTest.Test.Integracion
{
    [TestClass]
    public class ConceptosServiceModelTest
    {
        //Pruebas de modelo
        [TestMethod()]
        public void SConceptosGetCuentaGastosInstanciaTest()
        {
            ConceptosServiceModel target = new ConceptosServiceModel(); // TODO: Initialize to an appropriate value
            bool expected = true;
            bool actual;
            target.Nombre = "PruebaAutomatica";
            target.Descripcion = "Generacion de pruebas automaticas";
            actual = target.CreaConcepto();
            actual = target.GetCuentaGastosConceptos();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
            target.Descripcion = "Actualizado automaticamente";
            actual=target.ActualizaConcepto();
            Assert.AreEqual(expected, actual);
            actual = target.BorraConcepto();
            Assert.AreEqual(expected, actual);
        }
    }
}
