using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMFacilitoInicial.Models
{
    public class Telefono
    {
        public int TelefonoId { get; set; }

        public string NumeroTelefonico { get; set; }

        public string Tipo { get; set; }

        public bool Principal { get; set; }
    }
}