using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP2184587.Models;

namespace ASP2184587.Controllers
{
    public class compraController : Controller
    {
        // GET: compra
        public ActionResult Index()
        {
            using (var db = new inventarioEntities())
            {
                return View(db.compra.ToList());
            }
        }

        public static string NombreCliente(int? idcliente)
        {
            using (var db = new inventarioEntities())
            {
                return db.cliente.Find(idcliente).nombre;
            }
        }
        public ActionResult ListarClientes()
        {
            using (var db = new inventarioEntities())
            {
                return PartialView(db.cliente.ToList());
            }
        }

        public static string NombreUsuario(int? idusuario)
        {
            using (var db = new inventarioEntities())
            {
                return db.usuario.Find(idusuario).nombre;
            }
        }


        public ActionResult ListarUsuarios()
        {
            using (var db = new inventarioEntities())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compra compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioEntities())
                {
                    db.compra.Add(compra);
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
                compra compraEdit = db.compra.Where(a => a.id == id).FirstOrDefault();
                return View(compraEdit);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(compra compraEdit)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    var comp = db.compra.Find(compraEdit.id);
                    comp.fecha = compraEdit.fecha;
                    comp.total = compraEdit.total;
                    comp.id_cliente = compraEdit.id_cliente;
                    comp.id_usuario = compraEdit.id_usuario;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        public ActionResult Delete (int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    compra compra = db.compra.Find(id);
                    db.compra.Remove(compra);
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


