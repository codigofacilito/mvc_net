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
    [Authorize(Roles = "Admin, AdminAgenda")]
    public class CampaniasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Campanias
        public ActionResult Index()
        {
            return View(db.Campanias.ToList());
        }

        // GET: Campanias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campania campania = db.Campanias.Find(id);
            if (campania == null)
            {
                return HttpNotFound();
            }
            return View(campania);
        }

        // GET: Campanias/Create
        public ActionResult Create()
        {
            CampaniaViewModel campania = new CampaniaViewModel();
            return PartialView(campania);
        }

        // POST: Campanias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampaniaId,Nombre,Fecha,IncluyeProspectos")] 
                                    CampaniaViewModel campaniavm)
        {
            if (ModelState.IsValid)
            {
                Campania campania = new Campania();
                campania.Nombre = campaniavm.Nombre;
                campania.Fecha = campaniavm.Fecha;
                campania.FechaPlan = campaniavm.Fecha;
                campania.Publicada = false;
                if (campaniavm.IncluyeProspectos)
                {
                    var prospectos = (from c in db.Clientes
                                      where c.TipoClienteId == 1
                                      select c).ToList();
                    foreach (var item in prospectos)
                    {
                        campania.Actividades.Add(new Actividad
                            {
                                ClienteId = item.ClienteId,
                                FechaFinal = campania.Fecha.AddDays(-15),
                                FechaFinalPlan = campania.Fecha.AddDays(-15),
                                FechaInicial = campania.Fecha.AddDays(-15),
                                FechaInicialPlan = campania.Fecha.AddDays(-15),
                                Descripcion = "Llamar por telefono al cliente para la campaña " + campania.Nombre,
                                TipoActividadId = 6,
                                Estado = 0
                            });
                    }
                }
                db.Campanias.Add(campania);
                db.SaveChanges();
                return Json (new {success = true});
            }

            return PartialView(campaniavm);
        }

        // GET: Campanias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campania campania = db.Campanias.Find(id);
            if (campania == null)
            {
                return HttpNotFound();
            }
            CampaniaViewModel fcampania = new CampaniaViewModel();
            fcampania.CampaniaId = campania.CampaniaId;
            fcampania.Fecha = campania.Fecha;
            fcampania.Nombre = campania.Nombre;
            fcampania.Publicada = campania.Publicada;
            return View(fcampania);
        }

        // POST: Campanias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampaniaId,Nombre,FechaPlan,Fecha")] Campania campania)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campania).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campania);
        }

        // GET: Campanias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campania campania = db.Campanias.Find(id);
            if (campania == null)
            {
                return HttpNotFound();
            }
            return View(campania);
        }

        // POST: Campanias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campania campania = db.Campanias.Find(id);
            db.Campanias.Remove(campania);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MuestraDetalle(int idCampania)
        {
            CampaniaViewModel campania = new CampaniaViewModel();
            List<ActividadViewModel> actividades = campania.GetActividades(idCampania);
            campania.Dispose();
            return PartialView("_ListadoActividades", actividades);
        }

        public ActionResult AgregaActividad(int idCampania, int idCliente)
        {
            CampaniaViewModel fcampania = new CampaniaViewModel();
            if (!fcampania.ExisteCliente(idCampania, idCliente))
                fcampania.AgregaCliente(idCampania, idCliente);
            List<ActividadViewModel> actividades = new List<ActividadViewModel>();
            actividades = fcampania.GetActividades(idCampania);
            fcampania.Dispose();
            return PartialView("_ListadoActividades", actividades);
        }
        public ActionResult EliminaActividad(int idActividad)
        {
            Actividad actividad = db.Actividades.Find(idActividad);
            if (actividad != null)
            {
                int idCampania = (int)actividad.CampaniaId;
                db.Actividades.Remove(actividad);
                db.SaveChanges();
                Campania campania = db.Campanias.Find(idCampania);
                CampaniaViewModel fcampania = new CampaniaViewModel();
                fcampania.CampaniaId = campania.CampaniaId;
                fcampania.Fecha = campania.Fecha;
                fcampania.Nombre = campania.Nombre;
                return View("Edit", fcampania);
            }
            else
                return HttpNotFound();
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
