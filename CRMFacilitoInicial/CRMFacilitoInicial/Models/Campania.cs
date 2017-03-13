using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMFacilitoInicial.Models
{
    public class Campania
    {
        public int CampaniaId { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaPlan { get; set; }

        public DateTime Fecha { get; set; }

        public bool Publicada { get; set; }

        public ICollection<Actividad> Actividades { get; set; }

        public Campania()
        {
            Actividades = new List<Actividad>();
        }
    }
}