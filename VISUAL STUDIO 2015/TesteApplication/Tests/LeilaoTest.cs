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
    class LeilaoTest
    {
        [Test]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new Leilao("Motocicleta 150 cc");
            var usuario = new Usuario("Cesar");
                
            //validada se nenhum lance foi dado.
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(usuario, 1000d));

            //validade o teste com quantidade de lance e o valor que deve ser encontrado no lance único.
            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(1000d, leilao.Lances[0].ValorLance);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            var leilao = new Leilao("Play Station 3 Novo");

            var leonardo = new Usuario("Leonardo");
            var leandro = new Usuario("Leandro");

            leilao.Propoe(new Lance(leonardo, 1500));
            leilao.Propoe(new Lance(leandro, 2000));
            leilao.Propoe(new Lance(leonardo, 3000));
            leilao.Propoe(new Lance(leandro, 3600));

            Assert.AreEqual(4,leilao.Lances.Count);
            Assert.AreEqual(1500, leilao.Lances[0].ValorLance);
            Assert.AreEqual(3600, leilao.Lances[3].ValorLance);

        }

        [Test]
        public void NaoPodeTerDoisLancesSeguidosDoMesmoUSuario()
        {
            var leilao = new Leilao("Yamaha Fazer 250");

            var tiao = new Usuario("Sebastiao");
            var tiago = new Usuario("Tiago");

            leilao.Propoe(new Lance(tiao,1500));
            leilao.Propoe(new Lance(tiago, 2000));
            leilao.Propoe(new Lance(tiago, 3000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(3000, leilao.Lances[leilao.Lances.Count - 1].ValorLance);

        }

        [Test]
        public void MaximoCincoLancePorUsuario()
        {

            var leilao = new Leilao("Yamaha Fazer 250");

            var tiao = new Usuario("Sebastiao");
            var tiago = new Usuario("Tiago");

            leilao.Propoe(new Lance(tiao, 1500));
            leilao.Propoe(new Lance(tiago, 2000));

            leilao.Propoe(new Lance(tiao, 2500));
            leilao.Propoe(new Lance(tiago, 3000));

            leilao.Propoe(new Lance(tiao, 3500));
            leilao.Propoe(new Lance(tiago, 4000));

            leilao.Propoe(new Lance(tiao, 4500));
            leilao.Propoe(new Lance(tiago, 5000));

            leilao.Propoe(new Lance(tiao, 5500));
            leilao.Propoe(new Lance(tiago, 6000));

            leilao.Propoe(new Lance(tiao, 5500));


            Assert.AreEqual(10, leilao.Lances.Count);
            Assert.AreEqual(tiago,leilao.Lances[leilao.Lances.Count-1].Usuario);
        }

        [Test]
        public void MaximoCincoLancePorUsuarioDobraLance()
        {

            var leilao = new Leilao("Yamaha Fazer 250");

            var tiao = new Usuario("Sebastiao");
            var tiago = new Usuario("Tiago");

            leilao.Propoe(new Lance(tiao, 1000));
            leilao.Propoe(new Lance(tiago, 1100));

            leilao.DobraLance(tiao);
            leilao.DobraLance(tiago);
            leilao.DobraLance(tiao);
            leilao.DobraLance(tiago);
            leilao.DobraLance(tiao);
            leilao.DobraLance(tiago);
            leilao.DobraLance(tiao);
            leilao.DobraLance(tiago);
            leilao.DobraLance(tiao);
            leilao.DobraLance(tiago);

            Assert.AreEqual(10, leilao.Lances.Count);
            Assert.AreEqual(tiago, leilao.Lances[leilao.Lances.Count - 1].Usuario);
            Assert.AreEqual(17600d, leilao.Lances[leilao.Lances.Count - 1].ValorLance);
        }

        [Test]
        public void NaoDeveDobrarCasoNaoHajaLanceAnterior()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");

            leilao.DobraLance(steveJobs);

            Assert.AreEqual(0, leilao.Lances.Count);
        }

    }
}
