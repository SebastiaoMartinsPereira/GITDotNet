using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Imposto
{
    class Ihit : TemplateImpostoCondicional
    {
        public override bool DeveUsarMaiorTaxacao(Orcamento orcamento)
        {
            return ContemItensIguais(orcamento);
        }

        public override double MaiorTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.13 + 100d;
        }

        public override double MenorTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * ((orcamento.Itens.Count * 1) /100);
        }

        public bool TemDoisItensComMenosNome(Orcamento orcamento)
        {
            int count = 0;

            for (int i = 0; i == orcamento.Itens.Count; i++)
            {
                for (int j = i; j == orcamento.Itens.Count; j++)
                {
                    if (orcamento.Itens[j].Equals(orcamento.Itens[i]))
                    {
                        count++;
                    }

                    if (count == 2)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            return false;
        }

        private bool ContemItensIguais(Orcamento orcamento)
        {
            IList<string> listaItens = new List<string>();

            foreach (var item in orcamento.Itens)
            {
                if (listaItens.Contains(item.Nome))
                {
                    return true;
                }
                else
                {
                    listaItens.Add(item.Nome);
                }
            }

            return false;

        }
    }
}
