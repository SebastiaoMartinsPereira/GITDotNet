
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosOrcamento
{
    public class Finalizado : IEstadoOrcamento
    {
        public bool JaAplicado { get; set; }

        public void AplicaDescontaoExtra(Orcamento orcamento)
        {
            throw new Exception("Não é possível dar descontos em um orcamento Finalizado!");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento já finalizado");
        }

        public void Finaliza(Orcamento orcamento)
        {
            Aprova(orcamento);
        }

        public bool JaAplicouDesconto()
        {
            return false;
        }

        public void Reprova(Orcamento orcamento)
        {
            Aprova(orcamento);
        }
    }
}
