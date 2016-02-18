using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Musica
{
    public class Piano
    {
        public void Toca (IList<INota> notas)
        {
            foreach (INota item in notas)
            {
                Console.Beep(item.Frequencia, 300);
            }
        }
    }
}
