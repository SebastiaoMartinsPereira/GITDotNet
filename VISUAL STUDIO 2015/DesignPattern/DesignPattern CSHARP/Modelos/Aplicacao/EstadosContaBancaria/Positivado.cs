
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosContaBancaria
{
    public class Positivado : IEstadoConta
    {
        public void Depositar(Conta conta, double valor)
        {
            conta.Deposita(valor - (valor*0.02));
        }

        public void Negativar(Conta conta)
        {
            throw new NotImplementedException();
        }

        public void Positivar(Conta conta)
        {
            throw new NotImplementedException();
        }

        public void Sacar(Conta conta, double valor)
        {
            conta.Saca(conta.Saldo - valor);
            if (conta.Saldo < 0) conta.Negativar();
        }
    }
}
