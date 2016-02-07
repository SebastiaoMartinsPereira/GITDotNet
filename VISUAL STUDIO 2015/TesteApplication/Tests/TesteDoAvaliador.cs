using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TesteApplication;


namespace Tests
{
    [TestFixture]
    class TesteDoAvaliador
    {
        private Avaliador leiloeiro;
        private IList<Usuario> Usuarios;

        //[SetUp] //diz para u Nunit que este método deve ser invocado sempre durante a chamada de qualquer outro método. O método deve ser public
        [Test]
        [SetUp]
        public void CriarAvaliador()
        {
            this.leiloeiro = new Avaliador();
            Console.WriteLine("inicializando teste!");
            Usuarios = new List<Usuario>();
            Usuarios.Add(new Usuario("João"));
            Usuarios.Add(new Usuario("José"));
            Usuarios.Add(new Usuario("Maria"));
        }


        [TearDown] //diz para u Nunit que este método deve ser invocado sempre ao finalizar qualquer outro método que possua a anotação TestB. O método deve ser public
        public void Finaliza()
        {
            Console.WriteLine("fim");
        }

        [Test]
        public void DeveEntenderLeilaoComApenasUmLance()
        {

            leiloeiro.Avalia(
                                 new CriadorDeLeiloes()
                                 .Para("PlayStation 3")
                                 .Lance(Usuarios[0], 1000.0)
                                 .Constroi()
                             );

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public  void LancesOrdemCrescente()
        {
            
            leiloeiro.Avalia(
                                new CriadorDeLeiloes().Para("Nitendo I")
                                .Lance(Usuarios[0], 250.00)
                                .Lance(Usuarios[1], 300.00)
                                .Lance(Usuarios[2], 400.00)
                                .Constroi()
                            );

            double maiorEsperado = 400d;
            double menorEsperado = 250d;

            Assert.AreEqual(maiorEsperado , leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado , leiloeiro.MenorLance);

        }


        [Test]
        public void LancesAleatorios()
        {
            leiloeiro.Avalia(
                                new CriadorDeLeiloes().Para("Play Station I")
                                .Lance(Usuarios[0], 200.00)
                                .Lance(Usuarios[1], 450.00)
                                .Lance(Usuarios[2], 120.00)
                                .Lance(Usuarios[0], 700.00)
                                .Lance(Usuarios[1], 630.00)
                                .Lance(Usuarios[2], 230.00)
                                .Constroi()
                            );

            Assert.AreEqual(700d, leiloeiro.MaiorLance);
            Assert.AreEqual(120d, leiloeiro.MenorLance);

        }



        [Test]
        public void LancesOrdemDecrescente()
        {

 
            double maiorEsperado = 400d;
            double menorEsperado = 250d;

            leiloeiro.Avalia(
                                new CriadorDeLeiloes().Para("Play Station 2")
                                .Lance(Usuarios[0], 400.00)
                                .Lance(Usuarios[1], 300.00)
                                .Lance(Usuarios[2], 250.00)
                                .Constroi()
                            );

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance,000005d);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance,000005d);

        }



        [Test]
        public void ValorMedio()
        {

            Leilao leilao = new Leilao("playStation 3");

            double medioEsperado = (250.00 + 300.00 + 400.00) / 3;

            leilao.Propoe(new Lance(Usuarios[0], 250.00));
            leilao.Propoe(new Lance(Usuarios[1], 300.00));
            leilao.Propoe(new Lance(Usuarios[2], 400.00));

            leiloeiro.Avalia(leilao);


            Assert.AreEqual(medioEsperado, leiloeiro.ValorMedio);

        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(Usuarios[0], 100.0));
            leilao.Propoe(new Lance(Usuarios[1], 200.0));
            leilao.Propoe(new Lance(Usuarios[0], 300.0));
            leilao.Propoe(new Lance(Usuarios[1], 400.0));

            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].ValorLance, 0.00001);
            Assert.AreEqual(300, maiores[1].ValorLance, 0.00001);
            Assert.AreEqual(200, maiores[2].ValorLance, 0.00001);
        }
        
        [Test]
        ///// http://www.nunit.org/index.php?p=exceptionAsserts&r=2.5 
        public void NaoDeveAvaliarLeilaoSemLances()
        {
            Assert.Throws( typeof(ArgumentNullException)
                           , new TestDelegate(GeraLeilaoSemLances));
        }

        [Test]
        ///// http://www.nunit.org/index.php?p=exceptionAsserts&r=2.5 
        public void NaoDeveAvaliarLeilaoComLanceDeValor0()
        {
            Assert.Throws<ArgumentException>(
                            new TestDelegate(GeraLeilaoComLanceValorZero));
        }


        public void GeraLeilaoSemLances()
        {
            this.leiloeiro.Avalia(new CriadorDeLeiloes().Para("Nada").Constroi());
        }


        public void GeraLeilaoComLanceValorZero()
        {
            this.leiloeiro.Avalia(new CriadorDeLeiloes().Para("Nada").Lance(Usuarios[0],0d).Constroi());
        }


        //[TestFixtureSetUp]
        [OneTimeSetUp]
        //Métodos anotados com [TestFixtureSetUp] são executados apenas uma vez, antes de todos os métodos de teste.
        public void TestandoBeforeClass()
        {
            Console.WriteLine("text fixture setup");
        }

        //[TestFixtureTearDown]
        [OneTimeTearDown]
        //O método anotado com [TestFixtureTearDown], por sua vez, é executado uma vez, após a execução do último método de teste da classe.
        public void TestandoAfterClass()
        {
            Console.WriteLine("test fixture tear down");
        }


    }
}
