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
    public class ProductosController : Controller
    {
        private DB_Trabajo_1Entities3 db = new DB_Trabajo_1Entities3();

        // GET: /Productos/
        public ActionResult Index()
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            var ttr_producto = db.tTR_Producto.Include(t => t.tTR_Categoria);
            return View(ttr_producto.ToList());
        }

        // GET: /Productos/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Producto ttr_producto = db.tTR_Producto.Find(id);
            if (ttr_producto == null)
            {
                return HttpNotFound();
            }
            return View(ttr_producto);
        }

        // GET: /Productos/Create
        public ActionResult Create()
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            ViewBag.iIdCategoria = new SelectList(db.tTR_Categoria, "iIdCategoria", "vNombreCategoria");
            ViewBag.iIdProveedor = new SelectList(db.tTR_Proveedor, "iIdProveedor", "vNombreProveedor");
            return View();
        }

        // POST: /Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="iIdProducto,iIdCategoria,vNombreProducto,vDescripcionProducto,nPrecioCompra,nPrecioVenta,iStockActual,iStockMinimo,iEstado,iIdProveedor")] tTR_Producto ttr_producto)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (ModelState.IsValid)
            {
                db.tTR_Producto.Add(ttr_producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iIdCategoria = new SelectList(db.tTR_Categoria, "iIdCategoria", "vNombreCategoria", ttr_producto.iIdCategoria);
            ViewBag.iIdProveedor = new SelectList(db.tTR_Proveedor, "iIdProveedor", "vNombreProveedor",ttr_producto.iIdProveedor);
            return View(ttr_producto);
        }

        // GET: /Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Producto ttr_producto = db.tTR_Producto.Find(id);
            if (ttr_producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.iIdCategoria = new SelectList(db.tTR_Categoria, "iIdCategoria", "vNombreCategoria", ttr_producto.iIdCategoria);
            ViewBag.iIdProveedor = new SelectList(db.tTR_Proveedor, "iIdProveedor", "vNombreProveedor", ttr_producto.iIdProveedor);
            return View(ttr_producto);
        }

        // POST: /Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="iIdProducto,iIdCategoria,vNombreProducto,vDescripcionProducto,nPrecioCompra,nPrecioVenta,iStockActual,iStockMinimo,iEstado,iIdProveedor")] tTR_Producto ttr_producto)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (ModelState.IsValid)
            {
                db.Entry(ttr_producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iIdCategoria = new SelectList(db.tTR_Categoria, "iIdCategoria", "vNombreCategoria", ttr_producto.iIdCategoria);
            ViewBag.iIdProveedor = new SelectList(db.tTR_Proveedor, "iIdProveedor", "vNombreProveedor", ttr_producto.iIdProveedor);
            return View(ttr_producto);
        }

        // GET: /Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tTR_Producto ttr_producto = db.tTR_Producto.Find(id);
            if (ttr_producto == null)
            {
                return HttpNotFound();
            }
            return View(ttr_producto);
        }

        // POST: /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.LogHelper = LogHelper.Log.WriteFooter();
            tTR_Producto ttr_producto = db.tTR_Producto.Find(id);
            db.tTR_Producto.Remove(ttr_producto);
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
