using DesignPattern_CSHARP.Modelos;
using DesignPattern_CSHARP.Modelos.ExemploDP;
using DesignPattern_CSHARP.Modelos.Imposto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            //DPStrategy.StrategyCalcImpostos();
            //DPStrategy.StrategyCalcInvestimentos();
            //DPChainResposability.ChainDescontos();
            //DPChainResposability.ChainRequisicao();
            //DPTemplateMethod.TemplateMethodRelatorios();
            //DPDecorator.DecoratorImpostos();
            DPDecorator.DecoratorFiltroContas();
        }
    }
}
