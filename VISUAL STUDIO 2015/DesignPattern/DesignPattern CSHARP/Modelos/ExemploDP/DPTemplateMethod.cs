using DesignPattern_CSHARP.Modelos.Aplicacao.Relatorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.ExemploDP
{
    public class DPTemplateMethod
    {
        public static void TemplateMethodRelatorios()
        {
            List<Conta> contas = new List<Conta>()
            { new Conta(0003,"BB01", "r santa rosa", "1146086451", "email@email.com", 00502,2, "Sebastiao", 2000, new DateTime(2015,1,1))
             ,new Conta(0003 ,"BB03", "r santa rosa", "1146086451", "email@email.com",00503, 2, "Sebastiao Martins", 3000,new DateTime(2015,1,1))
             ,new Conta(0005,"BB05", "r santa rosa", "1146086451", "email@email.com",00505, 2, "Sebastiao Martins Pereira", 5000,new DateTime(2015,1,1))
            };

            TemplateRelatorio relatorio = new Relatorio(Enum.Enums.TipoRelatorio.Complexo);

            IDictionary<Conta,string> relatorios =  relatorio.GeraRelatorio(contas);

            foreach (var item in relatorios.Values)
            {
                Console.WriteLine("{0}",item);
                Console.ReadKey();
            }
        }
    }
}
