using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Imposto
{
    /// <summary>
    /// Classe criada para exemplificar o Design Pattern Decorator
    /// define as funcionalidades nescessárias para que uma classe que filha também seja um imposto.
    /// </summary>
    public abstract class ClsImposto
    {
        public ClsImposto OutroImposto { get; set; }

        public ClsImposto(ClsImposto outroImposto) { OutroImposto = outroImposto; }
        public ClsImposto() { this.OutroImposto = null; }

        public abstract double Calcula(Orcamento orcamento);

        protected double ValorOutroImposto(Orcamento orcamento)
        {
            if (OutroImposto == null) return 0;
                return OutroImposto.Calcula(orcamento);
        }
    }
}
