using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Investimento
{
    interface IInvestimento
    {
        int Chance { get; }

        double Calcula(double valor);
    }
}
