using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_CSHARP.Modelos.Aplicacao.AcoesNotaFIscal
{
    public interface IAcoesComNF
    {
        void Executa(Notafiscal notaFiscal);
    }

    public class EnviadorDeEmail : IAcoesComNF
    {
        public void Executa(Notafiscal  notaFiscal)
        {
            Console.WriteLine("enviando por e-mail");
        }
    }

    public class NotaFiscalDao : IAcoesComNF
    {
        public void Executa(Notafiscal notaFiscal)
        {
            Console.WriteLine("salvando no banco");
        }
    }

    public class EnviadorDeSms : IAcoesComNF
    {
        public void Executa(Notafiscal notaFiscal)
        {
            Console.WriteLine("enviando por sms");
        }
    }

    public class Impressora : IAcoesComNF
    {
        public void Executa(Notafiscal notaFiscal)
        {
            Console.WriteLine("imprimindo notaFiscal");
        }
    }

    public class Multiplicador : IAcoesComNF
    {
        public double Fator { get; private set; }
        public Multiplicador(double fator) { this.Fator = fator; }

        public void Executa(Notafiscal notaFiscal)
        {
            Console.WriteLine("Multiplicando = " + notaFiscal.ValorBruto * this.Fator);
        }
    }
}
