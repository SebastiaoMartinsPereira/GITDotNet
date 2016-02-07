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
    class TestePaliandro
    {
        [Test]
        public void testePalindromo()
        {
            var frase = "Socorram - me subi no onibus em Marrocos";

            Palindromo verificador = new Palindromo();

            Assert.AreEqual(true, verificador.EhPalindromo(frase));

        }

        [Test]
        public void DeveIdentificarPalindromoEFiltrarCaracteresInvalidos()
        {
            Palindromo p = new Palindromo();

            bool resultado = p.EhPalindromo(
                "Socorram-me subi no onibus em Marrocos");
            Assert.IsTrue(resultado);
        }

        [Test]
        public void DeveIdentificarPalindromo()
        {
            Palindromo p = new Palindromo();

            bool resultado = p.EhPalindromo(
                "Anotaram a data da maratona");
            Assert.IsTrue(resultado);
        }

        [Test]
        public void DeveIdentificarSeNaoEhPalindromo()
        {
            Palindromo p = new Palindromo();

            bool resultado = p.EhPalindromo(
                "E preciso amar as pessoas como se nao houvesse amanha");
            Assert.IsFalse(resultado);
        }


    }
}
