using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Relatorio
{
    public abstract class TemplateRelatorio
    {
        public IDictionary<Conta,string> GeraRelatorio(List<Conta> contas)
        {
            if (DeveGerarRelatorioSimples(contas))
            {
                return RelatorioSimples(contas);
            }

            return RelatorioComplexo(contas);
        }

        protected abstract IDictionary<Conta,string> RelatorioComplexo(List<Conta> contas);
        protected abstract IDictionary<Conta,string> RelatorioSimples(List<Conta> contas);
        protected abstract bool DeveGerarRelatorioSimples(List<Conta> contas);
    }
}
