using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP2184587.Models;
using System.Web.Mvc;

namespace ASP2184587.Controllers
{
    public class proveedorController : Controller
    {
        // GET: proveedor
        public ActionResult Index()
        {
            using (var db = new inventarioEntities())
            {
                return View(db.proveedor.ToList());
            }

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventarioEntities())
                {

                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");


                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventarioEntities())
            {
                var proveedor = db.proveedor.Find(id);
                return View(proveedor);
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                   proveedor  find = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(find);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proveedor editprov)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    proveedor prov = db.proveedor.Find(editprov.id);
                    prov.nombre = editprov.nombre;
                    prov.direccion = editprov.direccion;
                    prov.telefono = editprov.telefono;
                    prov.nombre_contacto = editprov.nombre_contacto;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error" + ex);
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    var find = db.proveedor.Find(id);
                    db.proveedor.Remove(find);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }
    }
}


