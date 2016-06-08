namespace CRMFacilitoInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoClienteId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Tipo_TipoClienteId", "dbo.TipoClientes");
            DropIndex("dbo.Clientes", new[] { "Tipo_TipoClienteId" });
            RenameColumn(table: "dbo.Clientes", name: "Tipo_TipoClienteId", newName: "TipoClienteId");
            AlterColumn("dbo.Clientes", "TipoClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientes", "TipoClienteId");
            AddForeignKey("dbo.Clientes", "TipoClienteId", "dbo.TipoClientes", "TipoClienteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "TipoClienteId", "dbo.TipoClientes");
            DropIndex("dbo.Clientes", new[] { "TipoClienteId" });
            AlterColumn("dbo.Clientes", "TipoClienteId", c => c.Int());
            RenameColumn(table: "dbo.Clientes", name: "TipoClienteId", newName: "Tipo_TipoClienteId");
            CreateIndex("dbo.Clientes", "Tipo_TipoClienteId");
            AddForeignKey("dbo.Clientes", "Tipo_TipoClienteId", "dbo.TipoClientes", "TipoClienteId");
        }
    }
}
