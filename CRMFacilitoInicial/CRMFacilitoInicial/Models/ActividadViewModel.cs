using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMFacilitoInicial.Models
{
    public class ActividadViewModel
    {
        public int ActividadId { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaInicial { get; set; }

        public int TipoActividadId { get; set; }

        public int ClienteId { get; set; }

        public string nombre { get; set; }

        public string NombreTipo { get; set; }

        public string Telefonos { get; set; }

        public string Emails { get; set; }

        public void ObtenTelefonosYEmailsDeCliente()
        {
            ApplicationDbContext contexto = new ApplicationDbContext();
            Cliente cliente = contexto.Clientes.Find(ClienteId);
            contexto.Entry(cliente).Collection("Telefonos").Load();
            contexto.Entry(cliente).Collection("Correos").Load();
            Telefonos = "";
            bool inicio = true;
            foreach (var item in cliente.Telefonos)
            {
                if (inicio)
                {
                    Telefonos += item.NumeroTelefonico;
                    inicio = false;
                }
                else
                    Telefonos += ", " + item.NumeroTelefonico;
            }
            Emails = "";
            inicio = true;
            foreach (var item in cliente.Correos)
            {
                if (inicio)
                {
                    Emails += item.Direccion;
                    inicio = false;
                }
                else
                    Emails += ", " + item.Direccion;
            }
        }
    }
}