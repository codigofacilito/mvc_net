using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMFacilitoInicial.Models
{
    public class Actividad
    {
        public int ActividadId { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public DateTime FechaInicialPlan { get; set; }

        public DateTime FechaFinalPlan { get; set; }

        public int Estado { get; set; }

        public int TipoActividadId { get; set; }

        public int ClienteId { get; set; }

        public TipoActividad Tipo { get; set; }

        public Cliente ClienteActividad { get; set; }

        public int? CampaniaId { get; set; }

        public Campania CampaniaAct { get; set; }
    }
}