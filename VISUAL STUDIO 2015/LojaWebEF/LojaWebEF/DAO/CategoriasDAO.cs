using LojaWebEF.Entidades;
using LojaWebEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWebEF.DAO
{
    public class CategoriasDAO
    {
        private EntidadesContext contexto;

        public CategoriasDAO()
        {
            this.contexto = new EntidadesContext();
        }

        public void Adiciona(Categoria categoria)
        {
            contexto.Categorias.Add(categoria);
            contexto.SaveChanges();
        }

        public void Remove(Categoria categoria)
        {
            contexto.Categorias.Remove(categoria);
            contexto.SaveChanges();
        }

        public void Atualiza(Categoria categoria)
        {
            contexto.Entry(categoria).State = System.Data.EntityState.Modified;
            contexto.SaveChanges();
        }

        public Categoria BuscaPorId(int id)
        {
            return contexto.Categorias.Find(id);
        }

        public IEnumerable<Categoria> Lista()
        {
            return new List<Categoria>();
        }

        public IEnumerable<Categoria> BuscaPorNome(string nome)
        {
            return contexto.Categorias.AsEnumerable<Categoria>();
            //return new List<Categoria>();
        }

        public IEnumerable<ProdutosPorCategoria> ListaNumeroDeProdutosPorCategoria()
        {
            //return contexto.Categorias.Count<Categoria>(); 
            return new List<ProdutosPorCategoria>();
        }
    }

}