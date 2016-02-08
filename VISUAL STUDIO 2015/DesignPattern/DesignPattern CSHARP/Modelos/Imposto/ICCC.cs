using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Imposto
{
    class ICCC : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000d)
            {
                return orcamento.Valor * 0.05;
            }
            else if (orcamento.Valor > 1000d && orcamento.Valor < 3000d)
            {
                return orcamento.Valor * 0.07;
            }else if( orcamento.Valor > 3000d)
            {
                return orcamento.Valor * 0.08 + (30d);
            }

            return 0d;
        }
    }
}
