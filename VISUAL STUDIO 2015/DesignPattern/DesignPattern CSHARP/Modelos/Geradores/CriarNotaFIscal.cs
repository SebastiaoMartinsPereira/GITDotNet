using DesignPattern_CSHARP.Modelos.Aplicacao;
using DesignPattern_CSHARP.Modelos.Aplicacao.AcoesNotaFIscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    public class CriarNotaFIscal
    {
        public void DadosNotafiscal()
        {
            NotaFiscalBuilder criador = new NotaFiscalBuilder();
            Notafiscal nf;

            nf = criador.ComRazaoSocial("TiaoEmbalagens")
                .ComCnpj("0315080/0001-001")
                .ComDataEmissao(new DateTime(2016, 2, 2))
                .ComObservacoes("Observação qualquer")
                .IncluirItem(new ItemNotaFiscalBulder().ComDescricao("Item qualquer").ComValor(200).Criar())
                .IncluirItem(new ItemNotaFiscalBulder().ComDescricao("Outro item qualquer").ComValor(100d).Criar())
                .Criar();

            Console.WriteLine(nf.ValorBruto + "\n " + nf.Impostos);
            Console.ReadKey();

        }

        public void DadosNotafiscalRealizaAcoes()
        {
            NotaFiscalBuilder criador = new NotaFiscalBuilder();
            Notafiscal nf;

            nf = criador.ComRazaoSocial("TiaoEmbalagens")
                .ComCnpj("0315080/0001-001")
                .ComDataEmissao(new DateTime(2016, 2, 2))
                .ComObservacoes("Observação qualquer")
                .IncluirItem(new ItemNotaFiscalBulder().ComDescricao("Item qualquer").ComValor(200).Criar())
                .IncluirItem(new ItemNotaFiscalBulder().ComDescricao("Outro item qualquer").ComValor(100d).Criar())
                .AdicionaAcao(new EnviadorDeEmail())
                .AdicionaAcao(new NotaFiscalDao())
                .AdicionaAcao(new EnviadorDeSms())
                .AdicionaAcao(new Impressora())
                .AdicionaAcao(new Multiplicador(2.5d))
                .Criar();

            Console.WriteLine(nf.ValorBruto + "\n " + nf.Impostos);
            Console.ReadKey();
        }

        public void DadosNotafiscalRealizaAcoesNoConstrutor()
        {

            NotaFiscalBuilder criador = new NotaFiscalBuilder(new List<IAcoesComNF>()
                                                                {  new EnviadorDeEmail()
                                                                  ,new NotaFiscalDao()
                                                                  ,new EnviadorDeSms()
                                                                  ,new Impressora()
                                                                  ,new Multiplicador(2.5d)
                                                                }
                                                              );
            Notafiscal nf;

            nf = criador.ComRazaoSocial("TiaoEmbalagens")
                .ComCnpj("0315080/0001-001")
                .ComDataEmissao(new DateTime(2016, 2, 2))
                .ComObservacoes("Observação qualquer")
                .IncluirItem(new ItemNotaFiscalBulder().ComDescricao("Item qualquer").ComValor(200).Criar())
                .IncluirItem(new ItemNotaFiscalBulder().ComDescricao("Outro item qualquer").ComValor(100d).Criar())
                .Criar();

            Console.WriteLine(nf.ValorBruto + "\n " + nf.Impostos);
            Console.ReadKey();
        }
    }
}
