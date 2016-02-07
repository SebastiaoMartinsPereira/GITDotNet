using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApplication;

namespace Tests
{
    [TestFixture]
    class GeradorDePagamentoTest
    {
        [Test]
        public void DeveGerarPagamentoParaLeilaoEncerrado()
        {
            var leilaoDao = new Mock<LeilaoDaoFalso>();
            //var avaliador = new Mock<Avaliador>();
            var avaliador = new Avaliador();
            var pagamentoDao = new Mock<PagamentoDao>();

            CriadorDeLeiloes criador = new CriadorDeLeiloes();

            List<Leilao> leiloes = new List<Leilao>();

            leiloes.Add( criador.Para("Bicicleta Ergometrica", new DateTime(2016, 01, 25))
                                .Lance(new Usuario("Sebastião"), 500d)
                                .Lance(new Usuario("Daniela"), 700d)
                                .Constroi()
                         );

            //aqui estou falando que quando for utilizado oo metodo encerrados 
            //da classe leilaoDao ele não faça o que esta definido em seu códigoo e sim que me retorne a lista de leiloes 
            leilaoDao.Setup(l => l.encerrados()).Returns(leiloes);

            //também estou subescrevendo o retorno do atributo maior lance.
            //avaliador.Setup(a => a.MaiorLance).Returns(700d);

            Pagamento pagamentoRetornoMock = null;

            //Defino que sempre que o método salva for invocado independente do pagamento que está sendo passado como parametro
            //ele me fação um "retorno" do objeto pagamento que está sendo passado como parametro
            //então st uma variável como sendo este pagamento que sera retornado.
            pagamentoDao.Setup(p => p.Salva(It.IsAny<Pagamento>())).Callback<Pagamento>(r => pagamentoRetornoMock = r);

            GeradorDePagamento gerador = new GeradorDePagamento(leilaoDao.Object,avaliador,pagamentoDao.Object);

            gerador.Gera();

            Assert.AreEqual(700d, pagamentoRetornoMock.Valor);

        }

        [Test]
        public void deveEmpurrarParaOProximoDiaUtil()
        {
            var leilaoDao = new Mock<LeilaoDaoFalso>();
            var avaliador = new Avaliador();
            var pagamentoDao = new Mock<PagamentoDao>();

            CriadorDeLeiloes criador = new CriadorDeLeiloes();

            List<Leilao> leiloes = new List<Leilao>();

            leiloes.Add(criador.Para("Bicicleta Ergometrica", new DateTime(2016, 01, 25))
                                .Lance(new Usuario("Sebastião"), 500d)
                                .Lance(new Usuario("Daniela"), 700d)
                                .Constroi()
                         );

            leilaoDao.Setup(l => l.encerrados()).Returns(leiloes);

            Pagamento pagamentoRetorno = null;

            pagamentoDao.Setup(p => p.Salva(It.IsAny<Pagamento>())).Callback<Pagamento>(r => pagamentoRetorno = r);

            GeradorDePagamento gerador = new GeradorDePagamento(leilaoDao.Object, avaliador, pagamentoDao.Object);

            gerador.Gera();

            Assert.AreEqual(DayOfWeek.Monday, pagamentoRetorno.Data.DayOfWeek);
        }


        [Test]
        public void deveEmpurrarParaOProximoDiaUtilInterface()
        {
            var leilaoDao = new Mock<LeilaoDaoFalso>();
            var avaliador = new Avaliador();
            var pagamentoDao = new Mock<PagamentoDao>();
            var relogio = new Mock<Relogio>();

            CriadorDeLeiloes criador = new CriadorDeLeiloes();

            List<Leilao> leiloes = new List<Leilao>();

            leiloes.Add(criador.Para("Bicicleta Ergometrica", new DateTime(2016, 01, 25))
                                .Lance(new Usuario("Sebastião"), 500d)
                                .Lance(new Usuario("Daniela"), 700d)
                                .Constroi()
                         );

            relogio.Setup(r => r.hoje()).Returns(new DateTime(2016, 2, 2));

            leilaoDao.Setup(l => l.encerrados()).Returns(leiloes);

            Pagamento pagamentoRetorno = null;

            pagamentoDao.Setup(p => p.Salva(It.IsAny<Pagamento>())).Callback<Pagamento>(r => pagamentoRetorno = r);

            GeradorDePagamento gerador = new GeradorDePagamento(leilaoDao.Object, avaliador, pagamentoDao.Object,relogio.Object);

            gerador.Gera();

            Assert.AreEqual(DayOfWeek.Tuesday, pagamentoRetorno.Data.DayOfWeek);
        }

    }
}
