using DesignPattern_CSHARP.Modelos.Aplicacao.EstadosContaBancaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosContaBancaria
{
    public class Negativado : IEstadoConta
    {
        public void Depositar(Conta conta,double valor)
        {
            conta.Deposita(valor - (valor * 0.05));
            if (conta.Saldo > 0) conta.Positivar();
        }

        public void Negativar(Conta conta)
        {
            throw new Exception("O estado atual já é negativado!");
        }

        public void Positivar(Conta conta)
        {
            conta.AlterarEstado(new Positivado());
        }

        public void Sacar(Conta conta,double valor)
        {
            throw new Exception("O saldo da conta encontrasse negativo não é possivel realizar o saque");
        }
    }
}
