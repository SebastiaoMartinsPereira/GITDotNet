using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Investimento
{
    class Conservador : IInvestimento
    {
        public int Chance
        {
            get
            {
                return 100;
            }
        }

        public double Calcula(double valor)
        {
            return valor * 0.08;
        }
    }
}
