using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApplication
{
    public class EncerradorDeLeilao
    {
        public int total { get; private set; }
        private LeilaoDaoFalso dao;
        private Carteiro cateiro;

        public EncerradorDeLeilao( LeilaoDaoFalso dao,Carteiro  carteiro)
        {
            this.dao = dao;
            this.cateiro = carteiro;
            total =0;
        }

        public virtual void Encerra()
        {

            List<Leilao> todosLeiloesCorrentes = dao.correntes();

            foreach (var l in todosLeiloesCorrentes)
            {

                try
                {
                    if (ComecouSemanaPassada(l))
                    {
                        l.Encerra();
                        total++;
                        dao.atualiza(l);
                        this.cateiro.Envia(l);
                    }
                }
                catch (Exception)
                {
                    Console.Write("peguei no metodo encerra.");
                }

            }
        }


        public bool ComecouSemanaPassada(Leilao leilao)
        {
            return DiasEntre(leilao.dataInicio,DateTime.Now) >= 7;
        }


        private int DiasEntre(DateTime inicio, DateTime fim)
        {
            return (int)(fim - inicio).TotalDays;

        }

    }

    public interface RepositorioDeLeiloes
    {
        void salva(Leilao leilao);
        List<Leilao> encerrados();
        List<Leilao> correntes();
        void atualiza(Leilao leilao);
    }

    public class Carteiro
    {
        public virtual void Envia(Leilao leilao)
        {
            try
            {
                Console.Write("Opa!!! estou enviando");
            }
            catch (Exception)
            {
                Console.Write("Opa não deu");
            }
        }
    }


}
