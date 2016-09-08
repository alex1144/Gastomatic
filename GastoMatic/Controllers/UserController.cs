using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GastoMatic.Models;

namespace GastoMatic.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            UserServiceModel user = new UserServiceModel();

            user.Usuario = collection["Usuario"];
            user.Contrasena = collection["Contrasena"];
            bool loginOK = user.validateUserLogin();
            if (loginOK)
            {
                return RedirectToAction("Index");
            }
            else
            {

                return View();
            }
        }
        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult CreateUser()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult CreateUser(FormCollection collection)
        {
            try
            {
                UserServiceModel user = new UserServiceModel();
                user.Usuario = collection["Usuario"];
                user.Contrasena = collection["Contrasena"];
                user.Correo = collection["Correo"];
                user.Nombre = collection["Nombre"];
                user.ApellidoPaterno = collection["ApellidoPaterno"];
                user.ApellidoMaterno = collection["ApellidoMaterno"];
                user.CodigoAcreditacion = collection["CodigoAcreditacion"];
                user.Perfil = collection["Perfil"];
                
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

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
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

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
