using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GastoMatic.Models;
using System.Web.Script.Serialization;
namespace GastoMatic.Controllers
{
    public class CuentaGastoController : Controller
    {
        //
        // GET: /CuentaGasto/

        public ActionResult Index()
        {
            CuentaGastos cg = new CuentaGastos();
            ViewBag.Model = cg.listCuentaGastos();
            var jss = new JavaScriptSerializer();
            String js = jss.Serialize(cg.listCuentaGastos());
            ViewBag.json = js;
            return View();
        }

        //
        // GET: /CuentaGasto/Details/5

        public ActionResult Details(int id)
        {
            if (id > 0)
            {
                CuentaGastos cg = new CuentaGastos();
                CuentaGastosDetalle cgd = new CuentaGastosDetalle();
                cg.IdCuentaGastos = id;
                ViewBag.Model = cg.verCuentaGastos();
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

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
            try
            {
                // TODO: Add insert logic here
                CuentaGastos cg = new CuentaGastos()
                {
                    FechaCreacion = DateTime.Now,
                    FechaFinal = DateTime.Parse(collection.Get("FechaFinal")),
                    FechaInicial = DateTime.Parse(collection.Get("FechaInicial")),
                    NumeroAcreedor = collection.Get("NumeroAcreedor"),
                    Descripcion = collection.Get("Descripcion")
                };
                cg.crearCuentaGasto();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CuentaGasto/Edit/5

        public ActionResult Edit(int id)
        {
            CuentaGastos cg = new CuentaGastos()
            {
                IdCuentaGastos = id
            };
            return View(cg.verCuentaGastos());
        }

        //
        // POST: /CuentaGasto/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CuentaGastos cg = new CuentaGastos()
                {
                    FechaFinal = DateTime.Parse(collection.Get("FechaFinal")),
                    FechaInicial = DateTime.Parse(collection.Get("FechaInicial")),
                    NumeroAcreedor = collection.Get("NumeroAcreedor"),
                    Descripcion = collection.Get("Descripcion"),
                    IdCuentaGastos = Int32.Parse(collection.Get("IdCuentaGastos"))
                };
                cg.modificarCuentaGasto();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CuentaGasto/Delete/5

        public ActionResult Delete(int id)
        {
            CuentaGastos cg = new CuentaGastos()
            {
                IdCuentaGastos = id
            };
            return View(cg.verCuentaGastos());
        }

        //
        // POST: /CuentaGasto/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CuentaGastos cg = new CuentaGastos()
                {
                    IdCuentaGastos = id
                };
                cg.deleteCuentaCargo();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

