using StartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.DAO
{

    public class VendasDAO
    {
        private EstoqueContext contexto;
        public VendasDAO(EstoqueContext contexto)
        {
          
            this.contexto = contexto;
        }
        public void Adiciona(Venda venda)
        {
            foreach (Produto produto in venda.Produtos)
            {
                contexto.Produtos.Attach(produto);
            }


            contexto.Vendas.Add(venda);
        }
        public IEnumerable<Venda> Lista()
        {
            return contexto.Vendas.ToList();
        }
    }


}
