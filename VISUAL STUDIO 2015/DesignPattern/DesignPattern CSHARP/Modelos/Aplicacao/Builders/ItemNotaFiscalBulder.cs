using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao
{
    public class ItemNotaFiscalBulder
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }

        public ItemNotaFiscalBulder ComDescricao(string descricao)
        {
            this.Descricao = descricao;
            return this;
        }

        public ItemNotaFiscalBulder ComValor(double valor)
        {
            this.Valor = valor;
            return this;
        }

        public ItemNotaFiscal Criar()
        {
            return new ItemNotaFiscal(this.Descricao, this.Valor);
        }
    }
}
