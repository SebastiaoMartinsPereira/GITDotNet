using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao
{
    public interface IFormatRequisicao
    {
         IFormatRequisicao Proximo { get; set; }

         string MontaRetorno(Conta conta,Requisicao requisicao);
    }
}
