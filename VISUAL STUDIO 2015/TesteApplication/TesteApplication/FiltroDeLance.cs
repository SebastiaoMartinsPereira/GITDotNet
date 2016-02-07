using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApplication
{
    public class FiltroDeLances
    {
        public IList<Lance> Filtra(IList<Lance> lances)
        {
            IList<Lance> resultado = new List<Lance>();

            foreach (Lance lance in lances)
            {
                if (lance.ValorLance > 1000 && lance.ValorLance < 3000)
                    resultado.Add(lance);
                else if (lance.ValorLance > 500 && lance.ValorLance < 700)
                    resultado.Add(lance);
                else if (lance.ValorLance > 5000)
                    resultado.Add(lance);
                else if (lance.ValorLance < 500)
                    resultado.Add(lance);
            }

            return resultado;
        }
    }
}
