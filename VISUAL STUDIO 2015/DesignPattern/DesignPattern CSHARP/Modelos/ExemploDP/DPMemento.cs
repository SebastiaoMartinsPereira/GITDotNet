using DesignPattern_CSHARP.Modelos.Aplicacao.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.ExemploDP
{
    public class DPMemento
    {
        public static void  MementoHistorico()
        {
                Historico historico = new Historico();

                Contrato contrato = new Contrato(DateTime.Now, new Cliente("Sebastião","r:morrinhos"), Enum.Enums.TipoContrato.NOVO);
                historico.Adiciona(contrato.SalvaEstado());

                contrato.Avanca();
                historico.Adiciona(contrato.SalvaEstado());

                contrato.Avanca();
                historico.Adiciona(contrato.SalvaEstado());

                contrato.Avanca();
                historico.Adiciona(contrato.SalvaEstado());
        }
    }
}
