using StartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.DAO
{
    public class ProdutosDAO:IDisposable
    {
        private EstoqueContext Context;

        public ProdutosDAO(EstoqueContext context)
        {
            this.Context = context;
        }

        public void Adiciona(Produto produto)
        {
            
            Context.Produtos.Add(produto);
            // o Save foi passado para o ciltro SaveChangesFilter
            //Context.SaveChanges();
            
        }

        public void Remove(Produto produto)
        {
            this.Context.Produtos.Attach(produto);
            this.Context.Produtos.Remove(produto);
            this.Context.SaveChanges();
        }

        public IEnumerable<Produto> ProdutoComPrecoMaiorQue(double? valor)
        {
            var precoMin = valor.GetValueOrDefault(0);
            var produtos = from p in Context.Produtos
                           where p.Preco > precoMin
                           select p;

            return produtos.ToList();
        }

        public IList<Produto> Lista()
        {
            return this.Context.Produtos.ToList();
        }

        public Produto BuscaPorId(int id)
        {
            return this.Context.Produtos.Find(id);
        }

        public void Atualiza(Produto produto)
        {
            this.Context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<Produto> ProdutosDaCategoria(string nomeCategoria)
        {
            var produtos = from p in Context.Produtos
                           where p.Categoria.Nome == nomeCategoria
                           select p;

            return produtos.ToList();
        }

        public IEnumerable<Produto> ProdutosDaCategoriaComPrecoMaiorDoQue(string nomeCategoria, double? preco)
        {
            var precoMin = preco.GetValueOrDefault(0);
            var produtos = from p in Context.Produtos
                           where p.Categoria.Nome == nomeCategoria && p.Preco > precoMin
                           select p;
            return produtos.ToList();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ProdutosDAO() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
