using DesignPattern_CSHARP.Modelos.Imposto;
using DesignPattern_CSHARP.Modelos.Investimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.ExemploDP
{
    public class DPStrategy
    {
        public static void StrategyCalcImpostos()
        {
            IImposto icms = new Icms();
            IImposto iss = new Iss();
            IImposto iccc = new ICCC();

            Orcamento orcamento = new Orcamento(2000d);
            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            calculador.RealizaCalculo(orcamento, icms)
                          .RealizaCalculo(orcamento, iss)
                          .RealizaCalculo(orcamento, iccc);

            Console.WriteLine("Impostos sobre o orcamento!" + calculador.ValorCalculado);
            Console.WriteLine("VAlor Final = " + (orcamento.Valor + calculador.ValorCalculado));
            Console.ReadKey();
        }

        public static void StrategyCalcInvestimentos()
        {
            IInvestimento conservador = new Conservador();
            IInvestimento moderado = new Moderado();
            IInvestimento arrojado = new Arrojado();

            Conta conta= new Conta("Sebastiao",2000d);
            Conta conta2 = new Conta("Daniela",1000d);
           
            CalculadorDeInvestimentos calculador = new CalculadorDeInvestimentos();

            //investimentos avulsos utilizando cada tipo de investimento
            conta.Deposita(calculador.Investir(conta, conservador).ValorGerado);
            conta.Deposita(calculador.Investir(conta, arrojado).ValorGerado);
            conta.Deposita(calculador.Investir(conta, moderado).ValorGerado);


            Console.WriteLine("First turn " + conta.Saldo.ToString("#####.00"));

            //teste de uma segunda roda de de investimentos
            conta2.Deposita(calculador.Investir(conta2, conservador).Investir(conta2, moderado).Investir(conta2, arrojado).ValorGerado);

            Console.WriteLine("Second turn " + conta2.Saldo.ToString("#####.00"));

            Console.ReadKey();
        }
    }
}
