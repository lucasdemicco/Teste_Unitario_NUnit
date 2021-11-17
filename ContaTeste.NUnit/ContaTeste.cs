using BancoExemplo.Model;
using NUnit.Framework;
using System;

namespace ContaTeste.NUnit
{
    [TestFixture]
    public class ContaTeste
    {
        [Test]
        public void TestSacar()
        {
            Conta conta = new Conta("0009", 200);
            bool resultado = conta.Sacar(120);

            Assert.IsTrue(resultado);
        }
    }
}
