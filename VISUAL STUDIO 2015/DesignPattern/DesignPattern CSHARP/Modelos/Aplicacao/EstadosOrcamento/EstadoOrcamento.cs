using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.EstadosOrcamento
{ 
    public interface IEstadoOrcamento
    {
        bool JaAplicado { get; set; }
        void AplicaDescontaoExtra(Orcamento orcamento);
        bool JaAplicouDesconto();
        void Aprova(Orcamento orcamento);
        void Reprova(Orcamento orcamento);
        void Finaliza(Orcamento orcamento);
    }
}
