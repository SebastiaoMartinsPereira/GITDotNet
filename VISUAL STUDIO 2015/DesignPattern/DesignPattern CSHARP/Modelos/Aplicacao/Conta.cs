using DesignPattern_CSHARP.Modelos.Aplicacao;
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
        public int NumeroConta { get; private set; }
        public Int16 Digito { get; private set; }
        public Agencia AgenciaConta{ get; private set; }
        public DateTime DataAbertura { get; private set; }
        
        public Conta( int codigoAgencia,string nomeAgencia,string enderecoAgencia,string telefoneAgencia,string emailAgencia,
                    int numeroConta, Int16 digito,string nome,double saldo,DateTime dataAbertura) 
        {
            this.AgenciaConta = new Agencia(codigoAgencia,nomeAgencia,enderecoAgencia,telefoneAgencia, emailAgencia);

            this.NumeroConta = numeroConta;
            this.Digito = digito;
            this.Nome = nome;
            this.Saldo = saldo;
            this.DataAbertura = dataAbertura;
          
        }

        public Conta(string nome, double saldo)
        {
            this.AgenciaConta = null;
            this.NumeroConta = 0; 
            this.Digito = 0;
            this.Nome = nome;
            this.Saldo = saldo;
           
        }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }
    }
}
