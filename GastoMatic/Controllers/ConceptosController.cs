using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using System.Web.Services;
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

        public JsonResult IndexRest()
        {
            ConceptosServiceModel cs = new ConceptosServiceModel();
            return Json(cs.GetListCuentaGastos(), JsonRequestBehavior.AllowGet);
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
        public JsonResult SaveCreate(ConceptosServiceModel collection)
        {
            ConceptosServiceModel cs = new ConceptosServiceModel();
            bool status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here()
                cs.Nombre = collection.Nombre;
                cs.Descripcion = collection.Descripcion;
                if (cs.CreaConcepto())
                {
                    status = true;
                    message = "Thank you for submit your query";
                }
            }
            else
            {
                message = "Failed! Please try again";
            }
            return new JsonResult { Data = new { status = status, message = message } };

        }
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
            if (cs.GetCuentaGastosConceptos()) {
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
