using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    public class AplicaDescontoExtra
    {
        public void AplicarDescontoEx()
        {
            try
            {
                Orcamento orcamento = new Orcamento(2000);

                orcamento.AplicaDescontoExtra();

                orcamento.Aprova();

                orcamento.AplicaDescontoExtra();
                orcamento.AplicaDescontoExtra();
                orcamento.Finaliza();

                orcamento.AplicaDescontoExtra();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}
