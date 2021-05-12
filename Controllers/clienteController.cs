using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP2184587.Models;
using System.Web.Mvc;
using System.Text;

namespace ASP2184587.Controllers
{
    public class clienteController : Controller
    {
        // GET: cliente
        public ActionResult Index()
        {
            using (var db = new inventarioEntities())
            {
                return View(db.cliente.ToList());
            }

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventarioEntities())
                {

                    db.cliente.Add(cliente);
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
                var cliente = db.cliente.Find(id);
                return View(cliente);
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    cliente find = db.cliente.Where(a => a.id == id).FirstOrDefault();
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
        public ActionResult Edit(cliente editclient)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    cliente client = db.cliente.Find(editclient.id);
                    client.nombre = editclient.nombre;
                    client.documento = editclient.documento;
                    client.email = editclient.email;

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
                    var find = db.cliente.Find(id);
                    db.cliente.Remove(find);
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


