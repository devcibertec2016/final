using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datos;

namespace Web_1.Controllers
{
    public class UsuarioController : Controller
    {
        private DB_Trabajo_1Entities3 db = new DB_Trabajo_1Entities3();

        // GET: /Usuario/
        public ActionResult Index()
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            var ttr_usuarios = db.tTR_Usuarios.Include(t => t.tTR_Roles);
            return View(ttr_usuarios.ToList());
        }

        // GET: /Usuario/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Usuarios ttr_usuarios = db.tTR_Usuarios.Find(id);
            if (ttr_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(ttr_usuarios);
        }

        // GET: /Usuario/Create
        public ActionResult Create()
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            ViewBag.iIdRol = new SelectList(db.tTR_Roles, "iIdUsuario", "vNombreRol");
            return View();
        }

        // POST: /Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iIdUsuario,iIdRol,vNombreUsuario,vPassword,vNombre,vApellidos,iEstado")] tTR_Usuarios ttr_usuarios, HttpPostedFileBase files)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            string urlLocal = "../..";
            if (ModelState.IsValid)
            {
                if (files == null && ttr_usuarios.sRutaImagen == null)
                {
                    ttr_usuarios.sRutaImagen = "../../WebImage/no_image.png";
                }
                else
                {
                    var fileName = string.Format("/WebImage/{0}",
                             files.FileName);
                    files.SaveAs(this.Server.MapPath(fileName));
                    ttr_usuarios.sRutaImagen = urlLocal + fileName;
                }
                db.tTR_Usuarios.Add(ttr_usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iIdRol = new SelectList(db.tTR_Roles, "iIdUsuario", "vNombreRol", ttr_usuarios.iIdRol);
            return View(ttr_usuarios);
        }

        // GET: /Usuario/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Usuarios ttr_usuarios = db.tTR_Usuarios.Find(id);
            if (ttr_usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.iIdRol = new SelectList(db.tTR_Roles, "iIdUsuario", "vNombreRol", ttr_usuarios.iIdRol);
            return View(ttr_usuarios);
        }

        // POST: /Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iIdUsuario,iIdRol,vNombreUsuario,vPassword,vNombre,vApellidos,iEstado")] tTR_Usuarios ttr_usuarios, HttpPostedFileBase files)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            string urlLocal = "../..";
            if (ModelState.IsValid)
            {
                if (files == null && ttr_usuarios.sRutaImagen ==null)
                {
                    ttr_usuarios.sRutaImagen = "../../WebImage/no_image.png";
                }
                else
                {
                    var fileName = string.Format("/WebImage/{0}",
                             files.FileName);
                    files.SaveAs(this.Server.MapPath(fileName));
                    ttr_usuarios.sRutaImagen = urlLocal + fileName;
                }
                db.Entry(ttr_usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iIdRol = new SelectList(db.tTR_Roles, "iIdUsuario", "vNombreRol", ttr_usuarios.iIdRol);
            return View(ttr_usuarios);
        }

        // GET: /Usuario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Usuarios ttr_usuarios = db.tTR_Usuarios.Find(id);
            if (ttr_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(ttr_usuarios);
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            tTR_Usuarios ttr_usuarios = db.tTR_Usuarios.Find(id);
            db.tTR_Usuarios.Remove(ttr_usuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
