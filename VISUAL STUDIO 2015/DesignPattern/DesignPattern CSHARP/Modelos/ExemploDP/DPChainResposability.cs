using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.ExemploDP
{
    class DPChainResposability
    {

        public static void ChainDescontos()
        {
            CalculaDeDescontos calculador = new CalculaDeDescontos();
            Orcamento orcamento = new Orcamento(100d);

            orcamento.AdicionaItem(new Item("Lapis", 150));
            orcamento.AdicionaItem(new Item("Caneta", 250));

            var deconto = calculador.Calcula(orcamento);
            Console.WriteLine(deconto);
            Console.ReadKey();

        }

        public static void ChainRequisicao()
        {
            string retorno = "";

            Conta conta = new Conta("Daniela", 2500d);
            Requisicao requisicao = new Requisicao(Enum.Enums.Formato.PORCENTO);

            TrataRequisicao tratador = new TrataRequisicao();


            retorno = tratador.Tratar(conta, requisicao);

            Console.WriteLine(retorno);

            Console.ReadKey();

        }
    }
}
