namespace CRMFacilitoInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifica_actividades : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Actividads", "ClienteActividad_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Actividads", "Tipo_TipoActividadId", "dbo.TipoActividads");
            DropIndex("dbo.Actividads", new[] { "ClienteActividad_ClienteId" });
            DropIndex("dbo.Actividads", new[] { "Tipo_TipoActividadId" });
            RenameColumn(table: "dbo.Actividads", name: "ClienteActividad_ClienteId", newName: "ClienteId");
            RenameColumn(table: "dbo.Actividads", name: "Tipo_TipoActividadId", newName: "TipoActividadId");
            AlterColumn("dbo.Actividads", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Actividads", "TipoActividadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Actividads", "TipoActividadId");
            CreateIndex("dbo.Actividads", "ClienteId");
            AddForeignKey("dbo.Actividads", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.Actividads", "TipoActividadId", "dbo.TipoActividads", "TipoActividadId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actividads", "TipoActividadId", "dbo.TipoActividads");
            DropForeignKey("dbo.Actividads", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Actividads", new[] { "ClienteId" });
            DropIndex("dbo.Actividads", new[] { "TipoActividadId" });
            AlterColumn("dbo.Actividads", "TipoActividadId", c => c.Int());
            AlterColumn("dbo.Actividads", "ClienteId", c => c.Int());
            RenameColumn(table: "dbo.Actividads", name: "TipoActividadId", newName: "Tipo_TipoActividadId");
            RenameColumn(table: "dbo.Actividads", name: "ClienteId", newName: "ClienteActividad_ClienteId");
            CreateIndex("dbo.Actividads", "Tipo_TipoActividadId");
            CreateIndex("dbo.Actividads", "ClienteActividad_ClienteId");
            AddForeignKey("dbo.Actividads", "Tipo_TipoActividadId", "dbo.TipoActividads", "TipoActividadId");
            AddForeignKey("dbo.Actividads", "ClienteActividad_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
