using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    public class Conta
    {
        public double Saldo { get; private set; }
        public string Nome { get; private set; }

        public Conta(string nome,double saldo)
        {
            this.Nome = nome;
            this.Saldo = saldo;
        }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }
    }
}
