using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Imposto
{

    /// <summary>
    /// Classe utilizada para exemplificar o Design Pattern Template Method
    /// </summary>
    /// <remarks> como as classes de ipostos contiam rum algoritomo muito parecido 
    /// , para evitar muita repetição de código foi criado esta cklasse abstrata que possue o algoritimo geral
    ///  e elgus métodos que devem ser implementados pela classe concreta </remarks>
    /// 
    public abstract class TemplateImpostoCondicional :ClsImposto, IImposto
    {
        public TemplateImpostoCondicional(ClsImposto outroImposto) : base(outroImposto) { }
        public TemplateImpostoCondicional() : base() { }

        public override double Calcula(Orcamento orcamento)
        {
            if (DeveUsarMaiorTaxacao(orcamento))
            {
                return MaiorTaxacao(orcamento) + ValorOutroImposto(orcamento); 
            }
            else
            {
                return MenorTaxacao(orcamento) + ValorOutroImposto(orcamento);
            }

        }

        public abstract double MenorTaxacao(Orcamento orcamento);
        public abstract double MaiorTaxacao(Orcamento orcamento);
        public abstract bool DeveUsarMaiorTaxacao(Orcamento orcamento);
    }
}
