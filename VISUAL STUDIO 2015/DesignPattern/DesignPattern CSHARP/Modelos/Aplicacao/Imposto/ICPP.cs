using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Imposto
{
    public class ICPP : TemplateImpostoCondicional
    {

        public ICPP(ClsImposto outroImposto) : base(outroImposto) { }
        public ICPP() : base() { }

        public override bool DeveUsarMaiorTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 500d;
        }

        public override double MaiorTaxacao(Orcamento orcamento)
        {
              return orcamento.Valor * 0.07;
        }

        public override double MenorTaxacao(Orcamento orcamento)
        {
              return orcamento.Valor * 0.05; ;
        }
    }
}
