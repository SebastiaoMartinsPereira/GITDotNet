using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosOrcamento
{
    public class Aprovado : EstadoOrcamento
    {
        public void AplicaDescontaoExtra(Orcamento orcamento)
        {
            orcamento.Descontar(orcamento.Valor * 0.02);
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já aprovado!");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Aprovado());
        }

        public void Reprova(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Reprovado());
        }
    }
}
