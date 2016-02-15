using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosOrcamento
{
    public class Aprovado : IEstadoOrcamento
    {
        public bool JaAplicado {get;set;}

        public void AplicaDescontaoExtra(Orcamento orcamento)
        {
            if (this.JaAplicado)
            {
                throw new Exception("O desconto já aplicado dutante esta estado!!");
            }

            orcamento.Descontar(orcamento.Valor * 0.02);
            this.JaAplicado = true;
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já aprovado!");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Finalizado());
        }

        public bool JaAplicouDesconto()
        {
            return this.JaAplicado;
        }

        public void Reprova(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Reprovado());
        }
    }
}
