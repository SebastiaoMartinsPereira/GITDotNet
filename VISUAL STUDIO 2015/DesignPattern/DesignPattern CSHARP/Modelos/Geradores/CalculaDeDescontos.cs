using DesignPattern_CSHARP.Modelos.Desconto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    public class CalculaDeDescontos
    {
        public double Calcula(Orcamento orcamento)
        {

            IDesconto d1 = new Desconto5Itens();
            IDesconto d2 = new DescontoACimade500();
            IDesconto d3 = new DescontoProVendaCasada();
            IDesconto d4 = new SemDesconto();

            d1.Proximo = d2;
            d2.Proximo = d3;
            d3.Proximo = d4;

            return d1.Desconta(orcamento);
        }
    }
}
