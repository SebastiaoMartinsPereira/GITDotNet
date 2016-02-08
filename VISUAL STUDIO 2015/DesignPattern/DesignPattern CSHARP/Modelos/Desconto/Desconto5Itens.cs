using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Desconto
{
    public class Desconto5Itens :IDesconto 
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            if (orcamento.Itens.Count > 5)
            {
                return orcamento.Valor * 0.1;
            }

            return Proximo.Desconta(orcamento);
        }
    }

    public class DescontoACimade500 :IDesconto
    {
        public IDesconto Proximo {  get; set; }


        public double Desconta(Orcamento orcamento)
        {
            if (orcamento.Valor > 500)
            {
                return orcamento.Valor * 0.07;
            }

            return Proximo.Desconta(orcamento);

        }
    }

    public class DescontoProVendaCasada: IDesconto
    {
        public IDesconto Proximo { get; set; }
   
        public double Desconta(Orcamento orcamento)
        {
            
            if (Existe("Lapis", orcamento) && Existe("Caneta", orcamento))
            {
                Console.WriteLine("VendaCasada");
                return orcamento.Valor * 0.05;
                
            }

            return Proximo.Desconta(orcamento);

        }

        private bool Existe(String nomeDoItem, Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                if (item.Nome.Equals(nomeDoItem)) return true;
            }

            return false;
        }

    }


    public class SemDesconto : IDesconto
    {
        public IDesconto Proximo { get; set; }


        public double Desconta(Orcamento orcamento)
        {

            return 0;

        }
    }
}
