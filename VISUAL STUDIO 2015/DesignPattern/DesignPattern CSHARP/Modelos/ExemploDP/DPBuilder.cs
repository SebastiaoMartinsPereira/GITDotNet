using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.ExemploDP
{
    public class DPBuilder
    {
        public static void BuilderNotaFIscal()
        {
            CriarNotaFIscal criador = new CriarNotaFIscal();
            criador.DadosNotafiscal();
        }
    }
}
