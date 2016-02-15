using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Imposto
{
    public class Acpp : ClsImposto 
    {

        public Acpp(ClsImposto outroImposto) : base(outroImposto) { }
        public Acpp() : base() { }

        /// <summary>
        /// Este metodo utiliza conceitos do Design pattern Decoretor
        /// </summary>
        /// <param name="orcamento"></param>
        /// <returns></returns>
        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06 + ValorOutroImposto(orcamento);
        }
    }
}
