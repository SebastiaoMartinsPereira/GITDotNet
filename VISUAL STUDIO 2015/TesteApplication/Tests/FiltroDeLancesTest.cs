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
    public class FiltroDeLancesTest
    {
        [Test]
        public void DeveSelecionarLancesEntre1000E3000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao,2000),
            new Lance(joao,1000),
            new Lance(joao,3000),
            new Lance(joao, 800)});

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(2000, resultado[0].ValorLance, 0.00001);
        }

        [Test]
        public void DeveSelecionarLancesEntre500E700()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao,600),
            new Lance(joao,500),
            new Lance(joao,700),
            new Lance(joao, 800)});

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(600, resultado[0].ValorLance, 0.00001);
        }

        [Test]
        public void DeveSelecionarLancesMaior5000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao,6000),
            new Lance(joao,5005),
            new Lance(joao,7050),
            new Lance(joao, 800)});

            resultado = resultado.OrderByDescending(l => l.ValorLance).ToList() ;

            Assert.AreEqual(3, resultado.Count);
            Assert.AreEqual(7050, resultado[0].ValorLance, 0.00001);
        }

        [Test]
        public void DeveSelecionarLancesMenores500()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
            new Lance(joao,200),
            new Lance(joao,400),
            new Lance(joao,300),
            new Lance(joao,150)});

            resultado = resultado.OrderBy(l => l.ValorLance).ToList();

            Assert.AreEqual(4, resultado.Count);
            Assert.AreEqual(150, resultado[0].ValorLance, 0.00001);
        }
    }
}
