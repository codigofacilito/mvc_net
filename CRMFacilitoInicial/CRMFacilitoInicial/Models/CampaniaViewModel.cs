using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMFacilitoInicial.Models
{
    public class CampaniaViewModel
    {

        private ApplicationDbContext contexto;

        public CampaniaViewModel()
        {
            contexto = new ApplicationDbContext();
        }
        public int CampaniaId { get; set; }

        [Required]
        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public bool Publicada { get; set; }

        public int ClienteId { get; set; }

        public string NombreCliente { get; set; }

        public bool IncluyeProspectos { get; set; }

        public List<ActividadViewModel> GetActividades(int idCampania)
        {
            var consulta = from a in contexto.Actividades
                           join c in contexto.Clientes
                           on a.ClienteId equals c.ClienteId
                           join t in contexto.TipoActividades
                           on a.TipoActividadId equals t.TipoActividadId
                           where a.CampaniaAct.CampaniaId == idCampania
                           select new ActividadViewModel
                           {
                               ActividadId = a.ActividadId,
                               ClienteId = a.ClienteId,
                               nombre = c.Nombre,
                               FechaInicial = a.FechaInicial,
                               NombreTipo = t.Descripcion
                           };
            return consulta.ToList();
        }

        public bool ExisteCliente(int idCampania, int idCliente)
        {
            var consulta = from a in contexto.Actividades
                           where a.CampaniaId == idCampania && a.ClienteId == idCliente
                           select a;
            if (consulta.ToList().Count == 0)
                return false;
            else
                return true;
        }

        public void AgregaCliente(int idCampania, int idCliente)
        {
            Actividad actividad = new Actividad();
            Campania campania = new Campania();
            campania = contexto.Campanias.Find(idCampania);
            actividad.ClienteId = idCliente;
            actividad.FechaFinal = campania.Fecha.AddDays(-15);
            actividad.FechaFinalPlan = campania.Fecha.AddDays(-15);
            actividad.FechaInicial = campania.Fecha.AddDays(-15);
            actividad.FechaInicialPlan = campania.Fecha.AddDays(-15);
            actividad.Descripcion = "Llamar por telefono al cliente para la campaña " + campania.Nombre;
            actividad.TipoActividadId = 6;
            actividad.Estado = 0;
            actividad.CampaniaId = campania.CampaniaId;
            contexto.Actividades.Add(actividad);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}