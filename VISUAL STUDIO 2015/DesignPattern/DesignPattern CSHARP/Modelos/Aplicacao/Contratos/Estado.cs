using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Contratos
{
    public class Estado
    {
        public Contrato Contrato { get; private set; }
        public Estado (Contrato contrato)
        {
            this.Contrato = contrato;
        }
    }
}
