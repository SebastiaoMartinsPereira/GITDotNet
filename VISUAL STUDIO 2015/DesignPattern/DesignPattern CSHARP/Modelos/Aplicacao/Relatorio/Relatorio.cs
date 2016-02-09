using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Relatorio
{
    public class Relatorio : TemplateRelatorio
    {
        public Enum.Enums.TipoRelatorio TipoRelatorio { get; private set; }

        public Relatorio(Enum.Enums.TipoRelatorio tipoRelatorio)
        {
            this.TipoRelatorio = tipoRelatorio;
        }

        protected override bool DeveGerarRelatorioSimples(List<Conta> conta)
        {
            return this.TipoRelatorio == Enum.Enums.TipoRelatorio.Simples ? true : false;
        }


        protected override IDictionary<Conta,string> RelatorioComplexo(List<Conta> conta)
        {
            StringBuilder StbHeader;
            StringBuilder StbFooter;
            StringBuilder StbBody;

            Dictionary <Conta, string> dictionaryRel = new Dictionary<Conta, string>();

            foreach (var item in conta)
            {
                 StbHeader = new StringBuilder();
                 StbFooter = new StringBuilder();
                 StbBody = new StringBuilder();


                Agencia ag = item.AgenciaConta;

                StbHeader.AppendFormat("Banco : {0}\nEndereço : {1}\nTelefone : {2}\n---------------------------------------------\n", ag.Nome, ag.Endereco, ag.Telefone).ToString();

                StbBody.AppendFormat("Titular : {0}\nAgencia : {1}\nNúmero: {2}-{3}\nSaldo : {4}\n---------------------------------------------\n", item.Nome,ag.Codigo,item.NumeroConta,item.Digito,item.Saldo).ToString();

                StbFooter.AppendFormat("Email : {0}\nData : {1}\n---------------------------------------------\n", ag.Email, DateTime.Today.Date).ToString();

                dictionaryRel.Add(item, String.Format("{0}\n{1}\n{2}", StbHeader, StbBody, StbFooter));
            }

            return dictionaryRel;

        }

        protected override IDictionary<Conta,string> RelatorioSimples(List<Conta> contas)
        {

            StringBuilder StbHeader;
            StringBuilder StbFooter;
            StringBuilder StbBody;

            Dictionary<Conta, string> dictionaryRel = new Dictionary<Conta, string>();

            foreach (var item in contas)
            {
                 StbHeader = new StringBuilder();
                 StbFooter = new StringBuilder();
                 StbBody = new StringBuilder();

                Agencia ag = item.AgenciaConta;

                StbHeader.AppendFormat("Banco : {0}\n---------------------------------------------\n", ag.Nome).ToString();

                StbBody.AppendFormat("Titular : {0}\nSaldo : {1}\n---------------------------------------------\n",item.Nome,item.Saldo);

                StbFooter.AppendFormat("Telefone : {0}\n---------------------------------------------\n", ag.Telefone).ToString();

                dictionaryRel.Add(item, String.Format("Informações Bancarias:\n{0}\n{1}\n{2}\n", StbHeader, StbBody, StbFooter));

            }

            return dictionaryRel;

        }
    }
}
