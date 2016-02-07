
using StartProject.Models;
using System.Data.Entity;

namespace StartProject.DAO
{
    public class EstoqueContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<CategoriaDoProduto> Categorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        //mapeamentos
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Venda>()
        //            .HasMany(x => x.Produtos)
        //            .WithMany()
        //            .Map(relacionamento =>
        //            {
        //                relacionamento.ToTable("Venda_Produtos");
        //                relacionamento.MapLeftKey("VendaId");
        //                relacionamento.MapRightKey("Produto_Id");
        //            });
        //}

    }
}
