using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Enum
{
    public class Enums
    {
        [Flags]
        public enum Formato
        {
            XML = 1 ,CSV,PORCENTO
        }

        public enum TipoRelatorio { Simples,Complexo}
    }


}
