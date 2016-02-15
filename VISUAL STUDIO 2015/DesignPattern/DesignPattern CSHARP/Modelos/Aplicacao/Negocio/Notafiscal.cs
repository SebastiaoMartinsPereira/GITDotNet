using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao
{
    public class Notafiscal
    {
        string RazaoSocial { get; set; }
        public string Cnpj { get; private set; }
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public string Observacoes { get; private set; }
        public IList<ItemNotaFiscal> Itens { get; private set; }

        public Notafiscal(string razaoSocial,string cnpj,double valorBruto,double impostos,string observacoes,IList<ItemNotaFiscal> itens, DateTime? dataEmissao  = null)
        {
            this.RazaoSocial = razaoSocial;
            this.Cnpj = cnpj;
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
            this.Observacoes = observacoes;
            this.DataEmissao = dataEmissao ?? DateTime.Now;
            this.Itens = itens;
        }

    }
}
