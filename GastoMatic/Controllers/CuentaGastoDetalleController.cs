using System;
using System.Collections.Generic;
using System.Collections;
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

        public JsonResult IndexRest(int id)
        {
            CuentaGastosDetalle cgd = new CuentaGastosDetalle()
            {
                CuentaGastoId = id
            };
            return Json(cgd.listCuentaGastosDetalle(), JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /CuentaGastosDetalle/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CuentaGastosDetalle/Create/1

        public ActionResult Create(int id)
        {
            if (id > 0)
            {
                CuentaGastos cg = new CuentaGastos()
                {
                    IdCuentaGastos = id
                };

                CuentaGastosDetalle cgd = new CuentaGastosDetalle();
                ViewBag.Model = cg.verCuentaGastos();
                ConceptosServiceModel cs = new ConceptosServiceModel();
                List<ConceptosServiceModel> lis = new List<ConceptosServiceModel>();
                //
                lis.Add(new ConceptosServiceModel
                {
                    IdConcepto = 0,
                    Nombre = "Selecciona una opcion"
                });
                foreach(ConceptosServiceModel concepto in cs.GetListCuentaGastos()){
                    lis.Add(new ConceptosServiceModel {
                       IdConcepto =  concepto.IdConcepto,
                       Nombre = concepto.Nombre
                    });
                }
                SelectList lista = new SelectList(lis, "IdConcepto", "Nombre", 0);
                ViewBag.Lista = lista;
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
            var model = cgd.verCuentaGastosDetalle();
            ViewBag.CuentaGastoId = cgd.CuentaGastoId;
            ConceptosServiceModel cs = new ConceptosServiceModel();
            List<ConceptosServiceModel> lis = new List<ConceptosServiceModel>();
            //
            lis.Add(new ConceptosServiceModel
            {
                IdConcepto = 0,
                Nombre = "Selecciona una opcion"
            });
            foreach (ConceptosServiceModel concepto in cs.GetListCuentaGastos())
            {
                lis.Add(new ConceptosServiceModel
                {
                    IdConcepto = concepto.IdConcepto,
                    Nombre = concepto.Nombre
                });
            }
            SelectList lista = new SelectList(lis, "IdConcepto", "Nombre", 0);
            ViewBag.Lista = lista;
            return View(model);
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

