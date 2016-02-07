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
    class EncerradorDeLeilaoTeste
    {
        [Test]
        public void DeveEncerrarLeiloesQueComecaramUmaSemanaAntes()
        {
            DateTime data = new DateTime(2016, 01, 01);
            Leilao leilao1 = new Leilao("tv 20 polegadas",data);
            Leilao leilao2 = new Leilao("PlayStation", data);
            var carteiro = new Mock<Carteiro>();

            //LeilaoDaoFalso dao = new LeilaoDaoFalso();
            //dao.salva(leilao1);
            //dao.salva(leilao2);

            List<Leilao> leiloesAntigos = new List<Leilao>();
            leiloesAntigos.Add(leilao1);
            leiloesAntigos.Add(leilao2);

            var dao = new Mock<LeilaoDaoFalso>();
            dao.Setup(m => m.correntes()).Returns(leiloesAntigos);

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object,carteiro.Object);

            encerrador.Encerra();

            Assert.AreEqual(2, encerrador.total);
            Assert.IsTrue(leilao1.encerrado);
            Assert.IsTrue(leilao2.encerrado);

            //leiloesAntigos = encerrador.Encerra().ToList();

            //Assert.AreEqual(2, leiloesAntigos.Count);

            //Console.Write(leiloesAntigos.Count);
            //Console.Write(encerrador.ComecouSemanaPassada(leiloesAntigos[1]));

            //Assert.IsTrue(leiloesAntigos[0].encerrado);
            //Assert.IsTrue(leiloesAntigos[1].encerrado);
        }

        [Test]
        public void deveEncerrarLeiloesQueComecaramUmaSemanaAntes()
        {
            DateTime data = new DateTime(2014, 05, 05);

            Leilao leilao1 = new Leilao("Tv 20 polegadas",data);
            Leilao leilao2 = new Leilao("Play 2",data);
      
            List<Leilao> leiloesAntigos = new List<Leilao>();

            leiloesAntigos.Add(leilao1);
            leiloesAntigos.Add(leilao2);

            // criando o mock
            var dao = new Mock<LeilaoDaoFalso>();
            // ensinando a retornar os leiloes antigos quando chamar o correntes
            dao.Setup(m => m.correntes()).Returns(leiloesAntigos);

            var carteiro = new Mock<Carteiro>();

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object, carteiro.Object);
            encerrador.Encerra();


            Assert.AreEqual(2, leiloesAntigos.Count);
            Assert.IsTrue(leiloesAntigos[0].encerrado);
            Assert.IsTrue(leiloesAntigos[1].encerrado);

            //verifica se o método f oi invocado
            dao.Verify(m => m.atualiza(leilao1),Times.Once());
            dao.Verify(m => m.atualiza(leilao2),Times.Once());


        }


        [Test]
        public void VerificaAtualizacaoDuplicada()
        {
            Assert.Throws(typeof(Moq.MockException)
                          , new TestDelegate(deveEncerrarLeiloesQueComecaramUmaSemanaAntesVerificarAtualizacaoDuplicada));
        }


        [Test]
        public void deveEncerrarLeiloesQueComecaramUmaSemanaAntesVerificarAtualizacaoDuplicada()
        {
            DateTime data = new DateTime(2014, 05, 05);

            Leilao leilao1 = new Leilao("Tv 20 polegadas", data);
            Leilao leilao2 = new Leilao("Play 2", data);

            List<Leilao> leiloesAntigos = new List<Leilao>();

            leiloesAntigos.Add(leilao1);
            leiloesAntigos.Add(leilao2);

            // criando o mock
            var dao = new Mock<LeilaoDaoFalso>();
            // ensinando a retornar os leiloes antigos quando chamar o correntes
            dao.Setup(m => m.correntes()).Returns(leiloesAntigos);

            var carteiro = new Mock<Carteiro>();

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object,carteiro.Object);
            encerrador.Encerra();


            Assert.AreEqual(2, leiloesAntigos.Count);
            Assert.IsTrue(leiloesAntigos[0].encerrado);
            Assert.IsTrue(leiloesAntigos[1].encerrado);

            //verifica se o método f oi invocado
            dao.Verify(m => m.atualiza(leilao1), Times.AtLeast(2));
            dao.Verify(m => m.atualiza(leilao2));


        }

        [Test]
        public void NaoDeveAtualizaOsLeiloesComAteUmaSemana()
        {
            DateTime data = new DateTime(2016, 02, 06);
            Leilao leilao1 = new Leilao("Tv 20 polegadas",data);
            List<Leilao> listaRetorno = new List<Leilao>();
            listaRetorno.Add(leilao1);

            var dao = new Mock<LeilaoDaoFalso>();
            dao.Setup(m => m.correntes()).Returns(listaRetorno);

            var carteiro = new Mock<Carteiro>();

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object, carteiro.Object);
            encerrador.Encerra();

            dao.Verify(m => m.atualiza(leilao1), Times.Never  ());
        }

        [Test]
        public void deveContinuarAExecutarMesmoQuandoODaoFalha()
        {
            DateTime data = new DateTime(2014, 05, 05);
            Leilao leilao1 = new Leilao("Tv 20 polegadas",data  );

            Leilao leilao2 = new Leilao("Play 2",data);
          

            List<Leilao> listaRetorno = new List<Leilao>();
            listaRetorno.Add(leilao1);
            listaRetorno.Add(leilao2);

            var dao = new Mock<LeilaoDaoFalso>();
            dao.Setup(m => m.correntes()).Returns(listaRetorno);

            var carteiro = new Mock<Carteiro>();

            //aqui indico quanndo devo gerar a exceção em que método
            dao.Setup(m => m.atualiza(leilao1)).Throws(new Exception());
            carteiro.Setup(c => c.Envia(leilao2)).Throws(new Exception());

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object, carteiro.Object);
            encerrador.Encerra();

            dao.Verify(m => m.atualiza(leilao2));
            carteiro.Verify(c => c.Envia(leilao2));
        }

        [Test]
        public void deveContinuarAExecutarMesmoQuandoODaoEOCArteiroFalhaFalha()
        {
            DateTime data = new DateTime(2014, 05, 05);
            Leilao leilao1 = new Leilao("Tv 20 polegadas", data);

            Leilao leilao2 = new Leilao("Play 2", data);


            List<Leilao> listaRetorno = new List<Leilao>();
            listaRetorno.Add(leilao1);
            listaRetorno.Add(leilao2);

            var dao = new Mock<LeilaoDaoFalso>();
            dao.Setup(m => m.correntes()).Returns(listaRetorno);

            var carteiro = new Mock<Carteiro>();

            //aqui indico quanndo devo gerar a exceção em que método
            //dao.Setup(m => m.atualiza(leilao1)).Throws(new Exception());
            carteiro.Setup(c => c.Envia(leilao2)).Throws(new Exception());

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object, carteiro.Object);
            encerrador.Encerra();

            dao.Verify(m => m.atualiza(leilao2));
            carteiro.Verify(c => c.Envia(leilao2));
        }

        [Test]
        public void NaoDeveInvocarOEnvio()
        {
            DateTime data = new DateTime(2014, 05, 05);
            Leilao leilao1 = new Leilao("Tv 20 polegadas", data);

            Leilao leilao2 = new Leilao("Play 2", data);


            List<Leilao> listaRetorno = new List<Leilao>();
            listaRetorno.Add(leilao1);
            listaRetorno.Add(leilao2);

            var dao = new Mock<LeilaoDaoFalso>();
            dao.Setup(m => m.correntes()).Returns(listaRetorno);

            var carteiro = new Mock<Carteiro>();

            //aqui indico quanndo devo gerar a exceção em que método
            dao.Setup(m => m.atualiza(leilao1)).Throws(new Exception());
            dao.Setup(m => m.atualiza(leilao2)).Throws(new Exception());

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object, carteiro.Object);
            encerrador.Encerra();

            dao.Verify(m => m.atualiza(leilao2));
            carteiro.Verify(c => c.Envia(leilao1),Times.Never());
            carteiro.Verify(c => c.Envia(leilao2),Times.Never());
        }


        [Test]
        public void NaoDeveInvocarOEnvioItIsAny()
        {
            DateTime data = new DateTime(2014, 05, 05);
            Leilao leilao1 = new Leilao("Tv 20 polegadas", data);

            Leilao leilao2 = new Leilao("Play 2", data);


            List<Leilao> listaRetorno = new List<Leilao>();
            listaRetorno.Add(leilao1);
            listaRetorno.Add(leilao2);

            var dao = new Mock<LeilaoDaoFalso>();
            dao.Setup(m => m.correntes()).Returns(listaRetorno);

            var carteiro = new Mock<Carteiro>();

            //aqui indico quanndo devo gerar a exceção em que método
            dao.Setup(m => m.atualiza(leilao1)).Throws(new Exception());
            dao.Setup(m => m.atualiza(leilao2)).Throws(new Exception());

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object, carteiro.Object);
            encerrador.Encerra();

            //carteiro.Verify(c => c.Envia(leilao1), Times.Never());
            //carteiro.Verify(c => c.Envia(leilao2), Times.Never());

            //aqui informo que quero verificar todas as vezes que o método foi executado inependente de quem ele está enviado

            carteiro.Verify(c => c.Envia(It.IsAny<Leilao>()), Times.Never());

            //verify(carteiroFalso,never()).envia(NaoDeveInvocarOEnvioItIsAny(Leilao.class));
        }


    }
}
