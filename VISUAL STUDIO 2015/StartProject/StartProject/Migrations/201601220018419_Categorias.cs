namespace StartProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categorias : DbMigration
    {

        //comando para ativar e realizar update de informações pelo Packge Manager Console
        //PM> Enable-Migrations
        //PM> Add-Migration Categorias
        //Update-Database



        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaDoProdutoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(),
                    Descricao = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 20),
                        Preco = c.Single(nullable: false),
                        CategoriaID = c.Int(),
                        Descricao = c.String(),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaDoProdutoes", t => t.CategoriaID)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "CategoriaID", "dbo.CategoriaDoProdutoes");
            DropIndex("dbo.Produtoes", new[] { "CategoriaID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Produtoes");
            DropTable("dbo.CategoriaDoProdutoes");
        }
    }
}
