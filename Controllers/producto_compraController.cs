using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP2184587.Models;
using System.Web.Mvc;

namespace ASP2184587.Controllers
{
    public class producto_compraController : Controller
    {
        // GET: producto_compra
        public ActionResult Index()
        {
            using (var db = new inventarioEntities())
            {
                return View(db.producto_compra.ToList());
            }
        }

        public  static int  idCompra(int? idcompra)
        {
            using (var db = new inventarioEntities())
            {
                return db.compra.Find(idcompra).id;
            }
        }

        public static string NombreProducto(int? idproducto)
        {
            using (var db = new inventarioEntities())
            {
                return db.producto.Find(idproducto).nombre;
            }
        }

        public ActionResult ListarIdCompra()
        {
            using ( var db = new inventarioEntities())
            {
                return PartialView(db.compra.ToList());
            }
        }

        public ActionResult ListarNombresProducto()
        {
            using (var db = new inventarioEntities())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(producto_compra producto_Compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioEntities())
                {
                    db.producto_compra.Add(producto_Compra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventarioEntities())
            {
                producto_compra producompEdit = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                return View(producompEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(producto_compra producompEdit)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    var procomp = db.producto_compra.Find(producompEdit.id);
                    procomp.cantidad = producompEdit.cantidad;
                    procomp.id_compra = producompEdit.id_compra;
                    procomp.id_producto = producompEdit.id;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using(var db = new inventarioEntities())
            {
                return View(db.producto_compra.Find(id));
            }
        }

        public ActionResult Delete (int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    producto_compra producto_Compra = db.producto_compra.Find(id);
                    db.producto_compra.Remove(producto_Compra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }
    }
}