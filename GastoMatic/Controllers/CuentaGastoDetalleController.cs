using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GastoMatic.Models;

namespace GastoMatic.Controllers
{
    public class CuentaGastoDetalleController : Controller
    {
        //
        // GET: /CuentaGastosDetalle/

        public ActionResult Index(int id)
        {
            CuentaGastosDetalle cgd = new CuentaGastosDetalle()
            {
                CuentaGastoId = id
            };
            ViewBag.Model = cgd.listCuentaGastosDetalle();
            ViewBag.id = id;
            return View();
        }

        //
        // GET: /CuentaGastosDetalle/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CuentaGastosDetalle/Create

        public ActionResult Create(int id)
        {
            if (id > 0 && id != null)
            {
                CuentaGastos cg = new CuentaGastos()
                {
                    IdCuentaGastos = id
                };
                CuentaGastosDetalle cgd = new CuentaGastosDetalle();
                ViewBag.Model = cg.verCuentaGastos();
                return View();
            }
            else
            {
                return RedirectToAction("Index", new { id = id });
            }
        }

        //
        // POST: /CuentaGastosDetalle/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CuentaGastosDetalle cgd = new CuentaGastosDetalle()
                {
                    CuentaGastoId = Int32.Parse(collection.Get("CuentaGastoId")),
                    FolioFactura = collection.Get("FolioFactura"),
                    Fecha = DateTime.Parse(collection.Get("Fecha")),
                    Monto = Double.Parse(collection.Get("Monto")),
                    Descripcion = collection.Get("Descripcion"),
                    IdConcepto = collection.Get("IdConcepto"),
                    MetodoPago = collection.Get("MetodoPago")
                };
                cgd.createCuentaGastoDetalle();
                return RedirectToAction("Index", new { id = Int32.Parse(collection.Get("CuentaGastoId")) });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CuentaGastosDetalle/Edit/5

        public ActionResult Edit(int id)
        {
            CuentaGastosDetalle cgd = new CuentaGastosDetalle()
            {
                IdCuentaGastosDetalle = id
            };
            return View(cgd.verCuentaGastosDetalle());
        }

        //
        // POST: /CuentaGastosDetalle/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CuentaGastosDetalle cgd = new CuentaGastosDetalle()
                {
                    IdCuentaGastosDetalle = id,
                    CuentaGastoId = Int32.Parse(collection.Get("CuentaGastoId")),
                    FolioFactura = collection.Get("FolioFactura"),
                    Fecha = DateTime.Parse(collection.Get("Fecha")),
                    Monto = Double.Parse(collection.Get("Monto")),
                    Descripcion = collection.Get("Descripcion"),
                    IdConcepto = collection.Get("IdConcepto"),
                    MetodoPago = collection.Get("MetodoPago")
                };
                cgd.modificarCuentaGastoDetalle();
                return RedirectToAction("Index", new { id = Int32.Parse(collection.Get("CuentaGastoId")) });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CuentaGastosDetalle/Delete/5

        public ActionResult Delete(int id)
        {
            CuentaGastosDetalle cgd = new CuentaGastosDetalle()
            {
                IdCuentaGastosDetalle = id
            };
            return View(cgd.verCuentaGastosDetalle());
        }

        //
        // POST: /CuentaGastosDetalle/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                CuentaGastosDetalle cgd = new CuentaGastosDetalle()
                {
                    IdCuentaGastosDetalle = id
                };
                cgd.deleteCuentaCargoDetalle();
                return RedirectToAction("Index", new { id = Int32.Parse(collection.Get("CuentaGastoId")) });
            }
            catch
            {
                return View();
            }
        }
    }
}

