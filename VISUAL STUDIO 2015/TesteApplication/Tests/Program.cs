using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApplication;

namespace Tests
{
    public class Program
    {
        public static void Main()
        {
            EncerradorDeLeilaoTeste test = new EncerradorDeLeilaoTeste();
            //test.DeveEncerrarLeiloesQueComecaramUmaSemanaAntes();
            //test.deveEncerrarLeiloesQueComecaramUmaSemanaAntes();

            GeradorDePagamentoTest geradorPagamentoTest = new GeradorDePagamentoTest();
            //geradorPagamentoTest.deveEmpurrarParaOProximoDiaUtil();
            geradorPagamentoTest.deveEmpurrarParaOProximoDiaUtilInterface();
        }
    }   
}
