using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GastoMatic.Models;

namespace GastoMatic.Controllers
{
    public class ConceptosController : Controller
    {
        //
        // GET: /Conceptos/

        public ActionResult Index()
        {
            ConceptosServiceModel cs = new ConceptosServiceModel();

            ViewBag.Models = cs.GetListCuentaGastos(); ;
            return View();
        }
        //
        // GET: /CuentaGasto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CuentaGasto/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ConceptosServiceModel cs = new ConceptosServiceModel();
            try
            {
                // TODO: Add insert logic here()
                cs.Nombre = collection["Nombre"];
                cs.Descripcion = collection["Descripcion"];
                if (cs.CreaConcepto())
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(cs);
            }
            return View(cs);
        }
        //
        // GET: /CuentaGasto/Update

        public ActionResult Update(int id)
        {
            ConceptosServiceModel cs = new ConceptosServiceModel();
            cs.IdConcepto = id;
            if (cs.GetCuentaGastos()) {
                //ViewBag.Model = cs;
            }

            return View(cs);
        }

        //
        // POST: /CuentaGasto/Update

        [HttpPost]
        public ActionResult Update(FormCollection collection)
        {
            ConceptosServiceModel cs = new ConceptosServiceModel();
            try
            {
                // TODO: Add insert logic here()
                cs.IdConcepto= int.Parse(collection["IdConcepto"]);
                cs.Nombre = collection["Nombre"];
                cs.Descripcion = collection["Descripcion"];
                if (cs.ActualizaConcepto())
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(cs);
            }
            return View(cs);
        }
        
        //
        // POST: /CuentaGasto/Update

        public ActionResult Delete(int id)
        {
            ConceptosServiceModel cs = new ConceptosServiceModel();
            try
            {
                // TODO: Add insert logic here()
                cs.IdConcepto = id;
                if (cs.BorraConcepto())
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(cs);
            }
            return View(cs);
        }
        public bool ValidateFields() {
            bool result = false;

            return result;
        }
    }
}
