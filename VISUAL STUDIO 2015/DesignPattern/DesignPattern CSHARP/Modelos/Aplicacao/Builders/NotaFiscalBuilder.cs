using DesignPattern_CSHARP.Modelos.Aplicacao.AcoesNotaFIscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao
{
    public class NotaFiscalBuilder
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public double ValorImpostos { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public string Observacoes { get; private set; }
        public IList<ItemNotaFiscal> Itens { get; private set; }
        public double ValorTotal { get; private set; }
        private IList<IAcoesComNF> acoes;

        public NotaFiscalBuilder()
        {
            Itens = new List<ItemNotaFiscal>();
            acoes = new List<IAcoesComNF>();
        }

        public NotaFiscalBuilder(List<IAcoesComNF> listaAcoes)
        {
            Itens = new List<ItemNotaFiscal>();
            acoes = listaAcoes;
        }

        public NotaFiscalBuilder AdicionaAcao(IAcoesComNF novaAcao)
        {
            this.acoes.Add(novaAcao);
            return this;
        }

        public NotaFiscalBuilder ComRazaoSocial(string razaoSocial)
        {
            this.RazaoSocial = razaoSocial;
            return this;
        }

        public NotaFiscalBuilder ComCnpj(string cnpj)
        {
            this.Cnpj = cnpj;
            return this;
        }

        public NotaFiscalBuilder ValorTotalImpostos(double valor)
        {
            this.ValorImpostos = valor;
            return this;
        }

        public NotaFiscalBuilder ComDataEmissao(DateTime dataEmissao)
        {
            this.DataEmissao = dataEmissao;
            return this;
        }

        public NotaFiscalBuilder ComObservacoes(string observacoes)
        {
            this.Observacoes = observacoes;
            return this;
        }

        public NotaFiscalBuilder IncluirItem(ItemNotaFiscal item)
        {
            this.Itens.Add(item);
            this.ValorTotal += item.Valor;
            this.ValorImpostos += item.Valor * 0.05;
            return this;
        }

        public Notafiscal Criar()
        {
            var nf = new Notafiscal(this.RazaoSocial, this.Cnpj, this.ValorTotal, this.ValorImpostos, this.Observacoes,this.Itens,this.DataEmissao);

            foreach (var item in acoes)
            {
                item.Executa(nf);
            }
            return nf;
        } 
    }
}
