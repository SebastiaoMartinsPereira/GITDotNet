using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao
{
    public class ItemNotaFiscal
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }

        public ItemNotaFiscal(string descricao,double valor)
        {
            this.Descricao = descricao;
            this.Valor = valor;
        }
    }
}
