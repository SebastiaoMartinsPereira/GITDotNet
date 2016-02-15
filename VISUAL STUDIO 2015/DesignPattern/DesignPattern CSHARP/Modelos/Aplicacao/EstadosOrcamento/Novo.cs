using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosOrcamento
{ 
    public class Novo : IEstadoOrcamento
    {
        public bool JaAplicado { get; set; }

        public void AplicaDescontaoExtra(Orcamento orcamento)
        {
            if (this.JaAplicado)
            {
                throw new Exception("O desconto já aplicado dutante esta estado!!");
            }

            orcamento.Descontar (orcamento.Valor * 0.05);
            this.JaAplicado = true;
        }

        public void Aprova(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Aprovado());
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Para ser finalizado o orcamento deve antes ser aprovado ou reporvado!!");
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
