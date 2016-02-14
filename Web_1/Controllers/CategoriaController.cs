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
    public class CategoriaController : Controller
    {
        private DB_Trabajo_1Entities3 db = new DB_Trabajo_1Entities3();

        // GET: /Categoria__/
        public ActionResult Index()
        
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            return View(db.tTR_Categoria.ToList());
        }

        // GET: /Categoria/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Categoria ttr_categoria = db.tTR_Categoria.Find(id);
            if (ttr_categoria == null)
            {
                return HttpNotFound();
            }
            return View(ttr_categoria);
        }

        // GET: /Categoria/Create
        public ActionResult Create()
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            return View();
        }

        // POST: /Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="iIdCategoria,vNombreCategoria,iEstado")] tTR_Categoria ttr_categoria)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (ModelState.IsValid)
            {
                db.tTR_Categoria.Add(ttr_categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ttr_categoria);
        }

        // GET: /Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Categoria ttr_categoria = db.tTR_Categoria.Find(id);
            if (ttr_categoria == null)
            {
                return HttpNotFound();
            }
            return View(ttr_categoria);
        }

        // POST: /Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="iIdCategoria,vNombreCategoria,iEstado")] tTR_Categoria ttr_categoria)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (ModelState.IsValid)
            {
                db.Entry(ttr_categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ttr_categoria);
        }


        public int AfterDelete(int? id)
        {
            int iEliminar = 0;
            int Registros = db.tTR_Producto.Where(n => n.iIdCategoria == id).Count();


            if (Registros == 0)
            {
                iEliminar = 1;
            }

            return iEliminar;
        }


        // GET: /Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            int Idelete = 0;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tTR_Categoria ttr_categoria = db.tTR_Categoria.Find(id);
           
            if (ttr_categoria == null)
            {
                return HttpNotFound();
            }
            Idelete = AfterDelete(ttr_categoria.iIdCategoria);
            ttr_categoria.iEstadoEliminar = Idelete;
            return View(ttr_categoria);
        }

        // POST: /Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            tTR_Categoria ttr_categoria = db.tTR_Categoria.Find(id);
            db.tTR_Categoria.Remove(ttr_categoria);
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
