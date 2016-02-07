using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApplication
{
    public class Pagamento
    {
        public double Valor { get; set; }
        public DateTime Data { get; set; }

        public Pagamento(double valor ,DateTime data)
        {
            this.Valor = valor;
            this.Data = data;

        }
    }

    public class PagamentoDao
    {
        public virtual void Salva(Pagamento pagamento) { }
    }
}
