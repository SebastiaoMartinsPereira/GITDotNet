using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos
{
    public class DeterminaEstadoConta
    {

        Conta conta01 = new Conta(0003, "brasil", "r,santarosa", "1146086451", "email@gmail.com", 00502, 2, "Sebastiao", 1500, DateTime.Now);
        Conta conta02 = new Conta(0003, "brasil", "r,santarosa", "1146086451", "email@gmail.com", 00502, 2, "Sebastiao Martins", -1200, DateTime.Now);


        public void TrabalhaEstadoConta()
        {
            try
            {
                conta01.Depositar(200);
                conta02.Depositar(200);
                conta01.Sacar(200);
                conta02.Sacar(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
