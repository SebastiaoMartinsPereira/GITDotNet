using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao
{
    public class TrataRequisicaoXml : IFormatRequisicao
    {
        public IFormatRequisicao Proximo { get; set; }

        public TrataRequisicaoXml()
        {
            this.Proximo = null;
        }

        public TrataRequisicaoXml(IFormatRequisicao proximo)
        {
            this.Proximo = proximo;
        }

        public string MontaRetorno(Conta conta, Requisicao requisicao)
        {
            if (requisicao.Formato == (Enum.Enums.Formato.XML))
            {
               return String.Format(
                    @"
                    <Conta>
                        < Nome >
                           {0}
                        </ Nome >
                        < Valor >
                           {1}
                        </ Valor>
                    </ Conta > 
                     ", conta.Nome, conta.Saldo);
            }
            else if (this.Proximo != null)
            {
                return Proximo.MontaRetorno(conta, requisicao);
            }
            else
            {
                throw new Exception("Não foi passado o formato a ser tratado");
            }

            
        }
    }

    public class TrataRequisicaoCSV: IFormatRequisicao
    {
        public IFormatRequisicao Proximo { get; set; }

        public TrataRequisicaoCSV()
        {
            this.Proximo = null;
        }
        public TrataRequisicaoCSV(IFormatRequisicao proximo)
        {
            this.Proximo = proximo;
        }

        public string MontaRetorno(Conta conta, Requisicao requisicao)
        {
            if (requisicao.Formato == (Enum.Enums.Formato.CSV))
            {
                return  String.Format(
                    @"
                    Conta:{0}|Nome:{1}|Valor:{2} 
                     ", conta,conta.Nome, conta.Saldo);
            }
            else if (this.Proximo != null)
            {
                return Proximo.MontaRetorno(conta, requisicao);
            }
            else
            {
                throw new Exception("Não foi passado o formato a ser tratado");
            }
            
        }
    }


    public class TrataRequisicaoPORCENTO : IFormatRequisicao
    {
        public IFormatRequisicao Proximo { get; set; }

        public TrataRequisicaoPORCENTO()
        {
            this.Proximo = null;
        }

        public TrataRequisicaoPORCENTO(IFormatRequisicao proximo)
        {
            this.Proximo = proximo;
        }

        public string MontaRetorno(Conta conta, Requisicao requisicao)
        {
            if (requisicao.Formato == (Enum.Enums.Formato.PORCENTO))
            {
                return String.Format(
                    @"
                    Conta:{0}%Nome:{1}%Valor:{2} 
                     ", conta, conta.Nome, conta.Saldo);
            }
            else if (this.Proximo != null)
            {
                return Proximo.MontaRetorno(conta, requisicao);
            }
            else
            {
                throw new Exception("Não foi passado o formato a ser tratado");
            }
        }
    }

}
