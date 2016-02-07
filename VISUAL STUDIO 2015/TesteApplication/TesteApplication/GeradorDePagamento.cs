using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApplication
{
    public class GeradorDePagamento
    {
        private LeilaoDaoFalso LeilaoDao  { get; set; }
        private PagamentoDao PagamentoDao {get;set;}
        private Avaliador Avaliador { get; set; }
        private Relogio RelogioSystema { get; set; }

        public GeradorDePagamento( LeilaoDaoFalso leilaoDao,Avaliador avaliador,PagamentoDao pagamentoDao,Relogio relogioSystema)
        {
            this.LeilaoDao = leilaoDao;
            this.Avaliador = avaliador;
            this.PagamentoDao = pagamentoDao;
            this.RelogioSystema = relogioSystema;

        }

        public GeradorDePagamento(LeilaoDaoFalso leilaoDao, Avaliador avaliador, PagamentoDao pagamentoDao)  
        {
            this.LeilaoDao = leilaoDao;
            this.Avaliador = avaliador;
            this.PagamentoDao = pagamentoDao;
            this.RelogioSystema = new RelogioDoSistema();
        }


        public virtual void Gera()
        {
            List<Leilao> encerrados = LeilaoDao.encerrados();

            foreach (var item in encerrados)
            {
                this.Avaliador.Avalia(item);

                Pagamento pagamento = new Pagamento(this.Avaliador.MaiorLance, proximoDiaUtil());

                this.PagamentoDao.Salva(pagamento);

            } 
        }

        public virtual DateTime proximoDiaUtil()
        {
            DateTime data = this.RelogioSystema.hoje();

            DayOfWeek diaSemana = data.DayOfWeek;

            if (diaSemana == DayOfWeek.Saturday)
            {
                data = data.AddDays(2d);
            }
            else if (diaSemana == DayOfWeek.Sunday)
            {
                data = data.AddDays(1d);
            }

            return data;
        }
    }

    public interface Relogio
    {
         DateTime hoje();
    }

    public class RelogioDoSistema : Relogio
    {
        public DateTime hoje()
        {
            return DateTime.Today;
        }
    }
}
