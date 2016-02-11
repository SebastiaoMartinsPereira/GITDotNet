using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosOrcamento
{ 
    public class Novo : EstadoOrcamento
    {
        public void AplicaDescontaoExtra(Orcamento orcamento)
        {
            orcamento.Descontar (orcamento.Valor * 0.05);
        }

        public void Aprova(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Aprovado());
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Para ser finalizado o orcamento deve antes ser aprovado ou reporvado!!");
        }

        public void Reprova(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Reprovado());
        }
    }
}
