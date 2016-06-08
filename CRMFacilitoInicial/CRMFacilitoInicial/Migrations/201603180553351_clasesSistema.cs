namespace CRMFacilitoInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clasesSistema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividads",
                c => new
                    {
                        ActividadId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        FechaInicial = c.DateTime(nullable: false),
                        FechaFinal = c.DateTime(nullable: false),
                        FechaInicialPlan = c.DateTime(nullable: false),
                        FechaFinalPlan = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        CampaniaAct_CampaniaId = c.Int(),
                        ClienteActividad_ClienteId = c.Int(),
                        Tipo_TipoActividadId = c.Int(),
                    })
                .PrimaryKey(t => t.ActividadId)
                .ForeignKey("dbo.Campanias", t => t.CampaniaAct_CampaniaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteActividad_ClienteId)
                .ForeignKey("dbo.TipoActividads", t => t.Tipo_TipoActividadId)
                .Index(t => t.CampaniaAct_CampaniaId)
                .Index(t => t.ClienteActividad_ClienteId)
                .Index(t => t.Tipo_TipoActividadId);
            
            CreateTable(
                "dbo.Campanias",
                c => new
                    {
                        CampaniaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaPlan = c.DateTime(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CampaniaId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        RFC = c.String(),
                        TipoPersonaSat = c.String(),
                        ContactoCliente_ContactoId = c.Int(),
                        Tipo_TipoClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Contactoes", t => t.ContactoCliente_ContactoId)
                .ForeignKey("dbo.TipoClientes", t => t.Tipo_TipoClienteId)
                .Index(t => t.ContactoCliente_ContactoId)
                .Index(t => t.Tipo_TipoClienteId);
            
            CreateTable(
                "dbo.Contactoes",
                c => new
                    {
                        ContactoId = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(),
                        Principal = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactoId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailId = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        Principal = c.Boolean(nullable: false),
                        Contacto_ContactoId = c.Int(),
                        Cliente_ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.EmailId)
                .ForeignKey("dbo.Contactoes", t => t.Contacto_ContactoId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteId)
                .Index(t => t.Contacto_ContactoId)
                .Index(t => t.Cliente_ClienteId);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        DireccionId = c.Int(nullable: false, identity: true),
                        Calle = c.String(),
                        NumExterior = c.String(),
                        NumInterior = c.String(),
                        Colonia = c.String(),
                        Municipio = c.String(),
                        Estado = c.String(),
                        Principal = c.Boolean(nullable: false),
                        Contacto_ContactoId = c.Int(),
                        Cliente_ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.Contactoes", t => t.Contacto_ContactoId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteId)
                .Index(t => t.Contacto_ContactoId)
                .Index(t => t.Cliente_ClienteId);
            
            CreateTable(
                "dbo.Telefonoes",
                c => new
                    {
                        TelefonoId = c.Int(nullable: false, identity: true),
                        NumeroTelefonico = c.String(),
                        Tipo = c.String(),
                        Principal = c.Boolean(nullable: false),
                        Contacto_ContactoId = c.Int(),
                        Cliente_ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.TelefonoId)
                .ForeignKey("dbo.Contactoes", t => t.Contacto_ContactoId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteId)
                .Index(t => t.Contacto_ContactoId)
                .Index(t => t.Cliente_ClienteId);
            
            CreateTable(
                "dbo.TipoClientes",
                c => new
                    {
                        TipoClienteId = c.Int(nullable: false, identity: true),
                        NombreTipo = c.String(),
                    })
                .PrimaryKey(t => t.TipoClienteId);
            
            CreateTable(
                "dbo.TipoActividads",
                c => new
                    {
                        TipoActividadId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoActividadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actividads", "Tipo_TipoActividadId", "dbo.TipoActividads");
            DropForeignKey("dbo.Actividads", "ClienteActividad_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Tipo_TipoClienteId", "dbo.TipoClientes");
            DropForeignKey("dbo.Telefonoes", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Direccions", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Emails", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "ContactoCliente_ContactoId", "dbo.Contactoes");
            DropForeignKey("dbo.Telefonoes", "Contacto_ContactoId", "dbo.Contactoes");
            DropForeignKey("dbo.Direccions", "Contacto_ContactoId", "dbo.Contactoes");
            DropForeignKey("dbo.Emails", "Contacto_ContactoId", "dbo.Contactoes");
            DropForeignKey("dbo.Actividads", "CampaniaAct_CampaniaId", "dbo.Campanias");
            DropIndex("dbo.Telefonoes", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Telefonoes", new[] { "Contacto_ContactoId" });
            DropIndex("dbo.Direccions", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Direccions", new[] { "Contacto_ContactoId" });
            DropIndex("dbo.Emails", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Emails", new[] { "Contacto_ContactoId" });
            DropIndex("dbo.Clientes", new[] { "Tipo_TipoClienteId" });
            DropIndex("dbo.Clientes", new[] { "ContactoCliente_ContactoId" });
            DropIndex("dbo.Actividads", new[] { "Tipo_TipoActividadId" });
            DropIndex("dbo.Actividads", new[] { "ClienteActividad_ClienteId" });
            DropIndex("dbo.Actividads", new[] { "CampaniaAct_CampaniaId" });
            DropTable("dbo.TipoActividads");
            DropTable("dbo.TipoClientes");
            DropTable("dbo.Telefonoes");
            DropTable("dbo.Direccions");
            DropTable("dbo.Emails");
            DropTable("dbo.Contactoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Campanias");
            DropTable("dbo.Actividads");
        }
    }
}
