using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    class CalculadorDeImpostos
    {
        public double ValorCalculado { get; private set; }

        public CalculadorDeImpostos()
        {
            this.ValorCalculado = 0d;
        }

        public CalculadorDeImpostos RealizaCalculo(Orcamento orcamento, Imposto.IImposto imposto)
        {
            this.ValorCalculado += imposto.Calcula(orcamento);
            return this;
        }
    }
}
