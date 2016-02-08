using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    public class Requisicao
    {
        public Enum.Enums.Formato Formato { get; private set; }

        public Requisicao(Enum.Enums.Formato formato)
        {
            this.Formato = formato;
        }
    }
}
