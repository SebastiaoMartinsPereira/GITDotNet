using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.ExemploDP
{
    public class DPState
    {
        public static void StateEstadosOrcamento()
        {
            AplicaDescontoExtra aplica = new AplicaDescontoExtra();
            aplica.AplicarDescontoEx();
        }


        public static void StateEstadoConta()
        {
            DeterminaEstadoConta estado = new DeterminaEstadoConta();
            estado.TrabalhaEstadoConta();
        }
    }
}
