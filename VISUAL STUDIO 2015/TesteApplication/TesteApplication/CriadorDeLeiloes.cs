using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApplication
{
    public class CriadorDeLeiloes
    {

        Leilao leilao;

        public CriadorDeLeiloes() { }


        public CriadorDeLeiloes Para(string produtoLeilao)
        {
            this.leilao = new Leilao(produtoLeilao);
            return this;
        }


        public CriadorDeLeiloes Para(string produtoLeilao,DateTime data)
        {
            this.leilao = new Leilao(produtoLeilao,data);
            return this;
        }

        public CriadorDeLeiloes Lance(Usuario usuario, double valor)
        {
            this.leilao.Propoe(new TesteApplication.Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return this.leilao;
        }

    }

}
