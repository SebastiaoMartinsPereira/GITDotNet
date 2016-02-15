using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Investimento
{
    class Arrojado : IInvestimento
    {
        public int Chance
        {
            get
            {
                return new Random().Next(101);
            }
        }

        public double Calcula(double valor)
        {
            var chance = this.Chance;

            if (chance <= 20)
            {
                return valor * 0.05;
            }
            else if (chance <= 30)
            {
                return valor * 0.03;
            }
            else
            {
                return valor * 0.06;
            }
        }
    }
}
