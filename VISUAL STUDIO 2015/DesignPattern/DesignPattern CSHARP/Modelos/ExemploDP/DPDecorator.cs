using DesignPattern_CSHARP.Modelos.Aplicacao.Filtro;
using DesignPattern_CSHARP.Modelos.Imposto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.ExemploDP
{
    public static class DPDecorator
    {
        public static void DecoratorImpostos()
        {
            Orcamento orcamento = new Orcamento(5000d);
            ClsImposto pis = new Pis(new Acpp(new TaxVeryHigh(new Ikcv(new ICPP()))));

            double valor = pis.Calcula(orcamento);

            Console.WriteLine(valor);
            Console.ReadKey();
        }

        public static void  DecoratorFiltroContas()
        {
            List<Conta> contas = new List<Conta>()
            {
                 new Conta(0003, "BB3", "r morrinhos", "1146086451", "email@mail.com", 00050, 3, "Sebastiao", 99d, new DateTime(2015, 1, 1))
                ,new Conta(0003, "BB3", "r morrinhos", "1146086451", "email@mail.com", 00050, 3, "Sebastiao Martins", 200d, new DateTime(2015, 1, 1))
                ,new Conta(0003, "BB3", "r morrinhos", "1146086451", "email@mail.com", 00050, 3, "Sebastiao Pereira", 990d, new DateTime(2016, 2, 1))
                ,new Conta(0003, "BB3", "r morrinhos", "1146086451", "email@mail.com", 00050, 3, "Sebastiao Martins Pereira", 5000000d, new DateTime(2015, 2, 1))
             };

            Filtro filtroAbaixoLimite = new FiltroAbaixoDoLimiteMinimo(new ComSaldoMaiorQueOLimite(new AbertaEsteMes()));

            foreach (var item in filtroAbaixoLimite.Filtra(contas))
            {
                Console.WriteLine("Proprietário : " + item.Nome + "\nConta :" + item.NumeroConta + "\nSaldo :" + item.Saldo + "\nData Abetura : " + item.DataAbertura.ToShortDateString() + "\n\n");
            }

            Console.ReadKey();
        }
    }
}
