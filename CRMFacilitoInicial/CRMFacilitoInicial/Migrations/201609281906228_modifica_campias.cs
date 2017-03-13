namespace CRMFacilitoInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifica_campias : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Actividads", name: "CampaniaAct_CampaniaId", newName: "CampaniaId");
            RenameIndex(table: "dbo.Actividads", name: "IX_CampaniaAct_CampaniaId", newName: "IX_CampaniaId");
            AddColumn("dbo.Campanias", "Publicada", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campanias", "Publicada");
            RenameIndex(table: "dbo.Actividads", name: "IX_CampaniaId", newName: "IX_CampaniaAct_CampaniaId");
            RenameColumn(table: "dbo.Actividads", name: "CampaniaId", newName: "CampaniaAct_CampaniaId");
        }
    }
}
