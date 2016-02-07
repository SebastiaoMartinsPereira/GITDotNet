using StartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.DAO
{
    public class CategoriasDAO
    {
        private EstoqueContext Context;

        public CategoriasDAO(EstoqueContext context)
        {
            this.Context = context;
        }


        public void Adiciona(CategoriaDoProduto categoria)
        {
            using (var context = new EstoqueContext())
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
        }

        public IList<CategoriaDoProduto> Lista()
        { 
            return Context.Categorias.ToList();  
        }

        public CategoriaDoProduto BuscaPorId(int id)
        {
            using (var context = new EstoqueContext())
            {
                return context.Categorias.Find(id);
            }
        }

        public IEnumerable<CategoriaDoProduto> BuscaPorNome(string nomeCategoria)
        {
            using (var context = new EstoqueContext())
            {
                var c = from ctg in context.Categorias
                        where ctg.Nome == nomeCategoria
                        select ctg;

                return c.ToList();
            }
        }

        public void Atualiza(CategoriaDoProduto categoria)
        {
            Context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }

        public CategoriaDoProduto ProdutosNaCategoria(int CategoriaId)
        {
            return Context.Categorias.Find(CategoriaId);
        }

        public IEnumerable<object> ListaNumeroDeProdutosPorCategoria()
        {

            var listCategorias = from c in Context.Categorias
                                 select new { Categoria = c.Nome, Qunatidade = c.Produtos.Count };
            return listCategorias.ToList();
        }
    }
}
