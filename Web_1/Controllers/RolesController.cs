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
    public class RolesController : Controller
    {
        private DB_Trabajo_1Entities3 db = new DB_Trabajo_1Entities3();

        // GET: /Roles/
        public ActionResult Index()
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            return View(db.tTR_Roles.ToList());
        }

        // GET: /Roles/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Roles ttr_roles = db.tTR_Roles.Find(id);
            if (ttr_roles == null)
            {
                return HttpNotFound();
            }
            return View(ttr_roles);
        }

        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="iIdUsuario,vNombreRol,iEstado")] tTR_Roles ttr_roles)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (ModelState.IsValid)
            {
                db.tTR_Roles.Add(ttr_roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ttr_roles);
        }

        // GET: /Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Roles ttr_roles = db.tTR_Roles.Find(id);
            if (ttr_roles == null)
            {
                return HttpNotFound();
            }
            return View(ttr_roles);
        }

        // POST: /Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="iIdUsuario,vNombreRol,iEstado")] tTR_Roles ttr_roles)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (ModelState.IsValid)
            {
                db.Entry(ttr_roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ttr_roles);
        }
        public int AfterDelete(int? id)
        {
            int iEliminar = 0;
            int Registros = db.tTR_Usuarios.Where(n => n.iIdRol == id).Count();


            if (Registros == 0)
            {
                iEliminar = 1;
            }

            return iEliminar;
        }
        // GET: /Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            int Idelete = 0;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Roles ttr_roles = db.tTR_Roles.Find(id);
            if (ttr_roles == null)
            {
                return HttpNotFound();
            }
            Idelete = AfterDelete(ttr_roles.iIdUsuario);
            ttr_roles.iEstadoEliminar = Idelete;
            return View(ttr_roles);
        }

        // POST: /Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            tTR_Roles ttr_roles = db.tTR_Roles.Find(id);
            db.tTR_Roles.Remove(ttr_roles);
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
