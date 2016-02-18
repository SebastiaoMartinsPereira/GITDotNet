using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.Musica
{
    public class Tocador
    {
        public static void Tocar()
        {
            NotasMusicais notas = new NotasMusicais();

            IList<INota> ListaNotas = new List<INota>()
            {
                notas.Pega("do"),
                notas.Pega("re"),
                notas.Pega("mi"),
                notas.Pega("fa"),
                notas.Pega("sol"),
                notas.Pega("la"),
                notas.Pega("si"),
                notas.Pega("si"),
                notas.Pega("do"),
                notas.Pega("re")
            };

            Piano play = new Piano();
            play.Toca(ListaNotas);
        }
    }
}
