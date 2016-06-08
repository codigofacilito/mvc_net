using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMFacilitoInicial.Models;

namespace CRMFacilitoInicial.Controllers
{
    public class TipoActividadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoActividades
        public ActionResult Index()
        {
            return View(db.TipoActividades.ToList());
        }

        // GET: TipoActividades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoActividades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoActividadId,Descripcion")] TipoActividad tipoActividad)
        {
            if (ModelState.IsValid)
            {
                db.TipoActividades.Add(tipoActividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoActividad);
        }

        // GET: TipoActividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoActividad tipoActividad = db.TipoActividades.Find(id);
            if (tipoActividad == null)
            {
                return HttpNotFound();
            }
            return View(tipoActividad);
        }

        // POST: TipoActividades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoActividadId,Descripcion")] TipoActividad tipoActividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoActividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoActividad);
        }

        // GET: TipoActividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoActividad tipoActividad = db.TipoActividades.Find(id);
            if (tipoActividad == null)
            {
                return HttpNotFound();
            }
            return View(tipoActividad);
        }

        // POST: TipoActividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoActividad tipoActividad = db.TipoActividades.Find(id);
            db.TipoActividades.Remove(tipoActividad);
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
