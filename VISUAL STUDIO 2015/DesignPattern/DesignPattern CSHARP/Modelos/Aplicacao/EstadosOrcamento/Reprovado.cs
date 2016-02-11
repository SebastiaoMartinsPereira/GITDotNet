using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosOrcamento
{
    public class Reprovado : EstadoOrcamento
    {
        public void AplicaDescontaoExtra(Orcamento orcamento)
        {
            throw new Exception("Não é possível conceder desconto para um orçamento reprovado!");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Não é possível mudar o estado de Reprovado para Aprovado!");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Finalizado());
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento já se encontra reprovado!!");
        }
    }
}
