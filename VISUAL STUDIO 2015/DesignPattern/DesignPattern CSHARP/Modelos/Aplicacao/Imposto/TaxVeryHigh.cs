using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Imposto
{
    public class TaxVeryHigh : ClsImposto
    {

        public TaxVeryHigh(ClsImposto outroImposto) : base(outroImposto) { }
        public TaxVeryHigh() : base() { }

        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.2 + ValorOutroImposto(orcamento);
        }
    }
}
