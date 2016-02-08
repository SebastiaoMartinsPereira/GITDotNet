using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Investimento
{
    class Moderado : IInvestimento
    {
        public int Chance
        {
            get { return new Random().Next(101);  }
        }

        public double Calcula(double valor)
        {
            var chance = this.Chance;

            if (chance < 50)
            {
                return valor * 0.025;
            }

            return valor * 0.07;
        }
    }
}
