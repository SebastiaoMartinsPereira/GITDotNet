using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Imposto
{
    public class Pis : ClsImposto
    {
        public Pis(ClsImposto outroimposto) : base(outroimposto) { }
        public Pis() : base() { }

        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.005 + ValorOutroImposto(orcamento);
        }
    }
}
