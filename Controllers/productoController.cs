using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP2184587.Models;
using System.Web.Mvc;

namespace ASP2184587.Controllers
{
    public class productoController : Controller
    {
        //GET:Producto
        public ActionResult Index()
        {
            using (var db = new inventarioEntities())

            {
                return View(db.producto.ToList());
            }
        }
        public static string NombreProveedor(int? idproveedor)
        {
            using (var db = new inventarioEntities())
            {
                return db.proveedor.Find(idproveedor).nombre;
            }
        }

        public ActionResult ListarProveedores()
        {
            using (var db=new inventarioEntities())
            {
                return PartialView(db.proveedor.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto producto)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioEntities())
                {
                    db.producto.Add(producto);
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
                producto productoEdit = db.producto.Where(a => a.id == id).FirstOrDefault();;
                return View(productoEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (producto productoEdit)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    var prod = db.producto.Find(productoEdit.id);
                    prod.nombre = productoEdit.nombre;
                    prod.cantidad = productoEdit.cantidad;
                    prod.descripcion = productoEdit.descripcion;
                    prod.percio_unitario = productoEdit.percio_unitario;
                    prod.id_proveedor = productoEdit.id_proveedor;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "error " +ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventarioEntities())
            {
                return View(db.producto.Find(id));
            }
        }

        public ActionResult Delete (int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    producto producto = db.producto.Find(id);
                    db.producto.Remove(producto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
    }
}
        
    