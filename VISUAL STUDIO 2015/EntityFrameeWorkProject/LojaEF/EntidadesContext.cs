using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEF
{
  
    public class EntidadesContext : DbContext
    {
        public EntidadesContext()
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EntidadesContext>(null);



        //
        //TABELA USUARIOS
        //

            var usuarioBuilder = modelBuilder.Entity<Usuario>();

            //DEFINE O NOME DA TABELA
            usuarioBuilder.ToTable("tb0001_Usuarios");

            //DEFINE O NOME DAS COLUNAS
            usuarioBuilder.Property(usuario => usuario.ID)
                          .HasColumnName("idUsuario");
            usuarioBuilder.Property(usuario => usuario.Nome)
                          .HasColumnName("nomeUSUARIO");
            usuarioBuilder.Property(usuario => usuario.Senha)
                          .HasColumnName("senhaUSUARIO");
            usuarioBuilder.Property(usuario => usuario.Sobrenome)
                          .HasColumnName("sobrenomeUSUARIO");
        //
        //TABELA PRODUTOS
        //

            var produtoBuilder = modelBuilder.Entity<Produto>();

            //DEFINE O NOME DA TABELA
            produtoBuilder.ToTable("tb0101_Produtos");

            //DEFINE O NOME DAS COLUNAS
            produtoBuilder.Property(produto => produto.Nome)
                          .HasColumnName("nomePRODUTO");
            produtoBuilder.Property(produto => produto.Descricao)
                          .HasColumnName("descricaooPRODUTO");
            produtoBuilder.Property(produto => produto.Preco)
                          .HasColumnName("precoPRODUTO");
       }

    }


}
