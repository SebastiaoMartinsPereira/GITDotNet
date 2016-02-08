using DesignPattern_CSHARP.Modelos.Investimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    class CalculadorDeInvestimentos
    {
        public double ValorGerado { get; private set; }

        public CalculadorDeInvestimentos()
        {
            this.ValorGerado = 0;
        }

        public CalculadorDeInvestimentos Investir(Conta conta, IInvestimento investimento)
        {
            this.ValorGerado += investimento.Calcula(conta.Saldo);
            return this;
        }
    }
}
