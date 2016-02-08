using DesignPattern_CSHARP.Modelos.Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    public  class TrataRequisicao
    { 
        public string Tratar(Conta conta,Requisicao requisicao)
        {

            IFormatRequisicao trataXml = new TrataRequisicaoXml(
                                             new TrataRequisicaoCSV(
                                                  new TrataRequisicaoPORCENTO()));

            return trataXml.MontaRetorno(conta, requisicao);
        }
    }
}
