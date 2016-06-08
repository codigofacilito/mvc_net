using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMFacilitoInicial.Models
{
    public class Direccion
    {
        public int DireccionId { get; set; }

        public string Calle { get; set; }

        public string NumExterior { get; set; }

        public string NumInterior { get; set; }

        public string Colonia { get; set; }

        public string Municipio { get; set; }

        public string Estado { get; set; }

        public bool Principal { get; set; }
    }
}