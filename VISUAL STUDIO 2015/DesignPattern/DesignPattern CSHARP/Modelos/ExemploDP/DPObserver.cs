using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.ExemploDP
{
    public class DPObserver
    {
        public static void ObserverNotaFiscal()
        {
            CriarNotaFIscal criador = new CriarNotaFIscal();
            criador.DadosNotafiscalRealizaAcoes();
            criador.DadosNotafiscalRealizaAcoesNoConstrutor();
        }
    }
}
