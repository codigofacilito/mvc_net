using CRMFacilitoInicial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CRMFacilitoInicial.Controllers
{
    public class ConsultasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<Cliente> Get(string inicio)
        {
            var consulta = from c in db.Clientes
                           where c.Nombre.Contains(inicio)
                           select c;
            return consulta.ToList();
        }

        public Cliente Get(int id)
        {
            Cliente cliente = new Cliente();
            cliente = db.Clientes.Find(id);
            if(cliente != null)
            {
                db.Entry(cliente).Collection("Direcciones").Load();
                db.Entry(cliente).Collection("Telefonos").Load();
                db.Entry(cliente).Collection("Correos").Load();
            }
            return cliente;
        }

        public void Put(Cliente cliente)
        {
            Cliente clienteDb = db.Clientes.Find(cliente.ClienteId);
            if(clienteDb != null)
            {
                clienteDb.TipoClienteId = cliente.TipoClienteId;
                db.Entry(clienteDb).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}