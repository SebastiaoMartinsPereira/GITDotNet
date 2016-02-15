using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosContaBancaria
{
    public interface IEstadoConta
    {
        void Sacar(Conta conta,double valor);
        void Depositar(Conta conta,double valor);
        void Positivar(Conta conta);
        void Negativar(Conta conta);

    }
}
