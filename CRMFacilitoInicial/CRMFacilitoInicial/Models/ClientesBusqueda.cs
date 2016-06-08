using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMFacilitoInicial.Models
{
    public class ClientesBusqueda
    {
        public int ClienteId { get; set; }

        public string Nombre { get; set; }

        public string NombreContacto { get; set; }

        public string Tipo { get; set; }

        public string RFC { get; set; }

        public string TipoPersonaSat { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }
    }
}