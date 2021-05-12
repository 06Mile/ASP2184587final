using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP2184587.Models;
using System.Web.Mvc;
using System.Text;

namespace ASP2184587.Controllers
{
    public class usuarioController : Controller
    {
        // GET: usuario
        public ActionResult Index()
        {
            using (var db = new inventarioEntities())
            {
                return View(db.usuario.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(usuario usuario)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventarioEntities())
                {
                    usuario.password = usuarioController.HashSHA1(usuario.password);
                    db.usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");


                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("","Error"+ex);
                return View();
            }
        }
        public static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventarioEntities())
            {
                var usuario = db.usuario.Find(id);
                return View(usuario);
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                using(var db = new inventarioEntities())
                {
                    usuario find = db.usuario.Where(a => a.id == id).FirstOrDefault();
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
        public ActionResult Edit(usuario editusuario)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    usuario usa = db.usuario.Find(editusuario.id);
                    usa.nombre = editusuario.nombre;
                    usa.apellido = editusuario.apellido;
                    usa.fecha_nacimiento = editusuario.fecha_nacimiento;
                    usa.email = editusuario.email;
                    usa.password = editusuario.password;

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
                    var find = db.usuario.Find(id);
                    db.usuario.Remove(find);
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