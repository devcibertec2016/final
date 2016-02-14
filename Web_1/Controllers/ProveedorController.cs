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
    public class ProveedorController : Controller
    {
        private DB_Trabajo_1Entities3 db = new DB_Trabajo_1Entities3();

        // GET: /Proveedor/
        public ActionResult Index()
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            return View(db.tTR_Proveedor.ToList());
        }

        // GET: /Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Proveedor ttr_proveedor = db.tTR_Proveedor.Find(id);
            if (ttr_proveedor == null)
            {
                return HttpNotFound();
            }
            return View(ttr_proveedor);
        }

        // GET: /Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            return View();
        }

        // POST: /Proveedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vNombreProveedor,vRuc,vDireccion,vTelefono1,vTelefono2,iEstado")] tTR_Proveedor ttr_proveedor)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (ModelState.IsValid)
            {
                db.tTR_Proveedor.Add(ttr_proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ttr_proveedor);
        }

        // GET: /Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Proveedor ttr_proveedor = db.tTR_Proveedor.Find(id);
            if (ttr_proveedor == null)
            {
                return HttpNotFound();
            }
            return View(ttr_proveedor);
        }

        // POST: /Proveedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iIdProveedor,vNombreProveedor,vRuc,vDireccion,vTelefono1,vTelefono2,iEstado")] tTR_Proveedor ttr_proveedor)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (ModelState.IsValid)
            {
                db.Entry(ttr_proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ttr_proveedor);
        }


        public int AfterDelete(int? id)
        {
            int iEliminar = 0;
            int Registros = db.tTR_Producto.Where(n => n.iIdProveedor == id).Count();


            if (Registros == 0)
            {
                iEliminar = 1;
            }

            return iEliminar;
        }
        // GET: /Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            int Idelete = 0;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Proveedor ttr_proveedor = db.tTR_Proveedor.Find(id);
            if (ttr_proveedor == null)
            {
                return HttpNotFound();
            }

            Idelete = AfterDelete(ttr_proveedor.iIdProveedor);
            ttr_proveedor.iEstadoEliminar = Idelete;
            return View(ttr_proveedor);
        }

        // POST: /Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            tTR_Proveedor ttr_proveedor = db.tTR_Proveedor.Find(id);
            db.tTR_Proveedor.Remove(ttr_proveedor);
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
