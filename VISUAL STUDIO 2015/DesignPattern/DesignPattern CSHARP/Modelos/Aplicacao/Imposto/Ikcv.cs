using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Imposto
{
    public class Ikcv : TemplateImpostoCondicional
    {

        public Ikcv(ClsImposto outroImposto) : base(outroImposto) { }
        public Ikcv() : base() { }

        /// <summary>
        /// apenas devo definir as regras que serão utilizadas para realizar o calculo da taxa.
        /// </summary>
        /// <param name="orcamento"></param>
        /// <returns></returns>
        public override bool DeveUsarMaiorTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 500 && TemItemMaiorQue100Reais(orcamento);
        }

        public override double MaiorTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        public override double MenorTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }

        private bool TemItemMaiorQue100Reais(Orcamento orcamento)
        {
            foreach (Item item in orcamento.Itens)
            {
                if (item.Valor > 100) return true;
            }

            return false;
        }
    }
}
