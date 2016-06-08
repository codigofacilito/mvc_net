using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CRMFacilitoInicial.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {

        public string NombreCompleto { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar reclamaciones de usuario personalizado aquí
            userIdentity.AddClaim(new Claim("NombreCompleto", this.NombreCompleto));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CRMFacilitoInicial.Models.TipoActividad> TipoActividades { get; set; }
        public System.Data.Entity.DbSet<CRMFacilitoInicial.Models.TipoCliente> TipoClientes { get; set; }
        public System.Data.Entity.DbSet<CRMFacilitoInicial.Models.Actividad> Actividades { get; set; }
        public System.Data.Entity.DbSet<CRMFacilitoInicial.Models.Contacto> Contactos { get; set; }
        public System.Data.Entity.DbSet<CRMFacilitoInicial.Models.Direccion> Direcciones { get; set; }
        public System.Data.Entity.DbSet<CRMFacilitoInicial.Models.Email> Emails { get; set; }
        public System.Data.Entity.DbSet<CRMFacilitoInicial.Models.Telefono> Telefonos { get; set; }
        public System.Data.Entity.DbSet<CRMFacilitoInicial.Models.Campania> Campanias { get; set; }
        public System.Data.Entity.DbSet<CRMFacilitoInicial.Models.Cliente> Clientes { get; set; }

    }
}