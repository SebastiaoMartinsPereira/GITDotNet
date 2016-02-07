namespace LojaEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudaConfiguracoesBase1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb0101_Produtos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nomePRODUTO = c.String(),
                        descricaooPRODUTO = c.String(),
                        precoPRODUTO = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb0101_Produtos");
        }
    }
}
