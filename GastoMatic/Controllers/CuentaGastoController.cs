using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GastoMatic.Models;

namespace GastoMatic.Controllers
{
    public class CuentaGastoController : Controller
    {
        //
        // GET: /CuentaGasto/

        public ActionResult Index()
        {
            CuentaGastos cg = new CuentaGastos();
            cg.listCuentaGastos();
            return View();
        }

        //
        // GET: /CuentaGasto/Details/5

        public ActionResult Details(int id)
        {
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
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        //
        // POST: /CuentaGasto/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
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
            return View();
        }

        //
        // POST: /CuentaGasto/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
