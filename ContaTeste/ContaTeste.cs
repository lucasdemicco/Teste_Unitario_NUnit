using BancoExemplo.Model;
using NUnit.Framework;
using System;

namespace ContaTeste
{
    [TestFixture]
    public class ContaTeste
    {
        #region SetUp e TierDown
        Conta conta;

        //Antes do NUnit iniciar os testes ele inicia o SetUP
        [SetUp]
        public void SetUp()
        {
            conta = new Conta("0009", 200);
        }

        //Executa o SetUp apenas uma vez
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            conta = new Conta("0001", 1500);
        }

        //Executado uma única vez após um teste unitário
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            conta = null;
        }

        //Executado sempre após um teste unitário
        [TearDown]
        public void TearDown()
        {
            conta = null;
        }

        #endregion

        #region Principal

        [Test]
        public void TestSacar()
        {
            bool resultado = conta.Sacar(120);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void TestSacarSemSaldo()
        {
            bool resultado = conta.Sacar(50);

            Assert.IsFalse(resultado);
        }

        [Test]
        public void TestAssert()
        {
            #region Empty
            //Verifica String com valor 
            string s = "aa";
            Assert.IsNotEmpty(s);

            ////Verifca se a string é vazia
            //string s1 = string.Empty;
            //Assert.IsEmpty(s);
            #endregion

            #region Greater
            //Verifica se o 1º argumento int é maior que o 2º
            int a = 10;
            int b = 5;
            Assert.Greater(a, b);
            #endregion

            #region AreSame
            //Verifica se o 2º objeto é igual ao 1º em memória (apontando)
            Conta c2 = conta;
            Assert.AreSame(a, b);
            #endregion

            #region NULL
            //Verifica se o objeto ñão é nulo
            Conta c = new Conta("0001", 100);
            Assert.IsNotNull(c);

            //Verifica se o objeto é nulo
            Conta c3 = new Conta("0001", 100);
            Assert.IsNull(c3);
            #endregion

        }

        #endregion


        #region Atribuindo Teste Categorizado
        [Test]
        [Category("Valores inválidos")]
        public void TestNumerosNegativos()
        {
            bool resultado = conta.Sacar(- 100);
            Assert.IsFalse(resultado);
        }

        [Test]
        [Category("Valor zerado")]
        public void TestNumerosZerados()
        {
            bool resultado = conta.Sacar(0);
            Assert.IsFalse(resultado);
        }

        #endregion

        #region Teste de Exceptions
        [Test]
        [Category("Exceptions")]
        public void TesteDeExceptions()
        {
            //Só valida se a exceção for exatamente o argumento passado
            Assert.Throws<ArgumentOutOfRangeException>(delegate { conta.Sacar(-100); });

            //Também pode ser usado Assert.Catch -> Valida a exception atual ou exceptions acima de sua hierarquia
            //Assert.Catch<ArgumentOutOfRangeException>(delegate { conta.Sacar(-50) });
        }
        #endregion

        #region Parametrizando Testes
        [Test]
        //Cria um ou mais teste case, executando cada case e verificando se ele passa no teste
        [TestCase(-850, false)]
        [TestCase(100, true)]
        [Category("Parametrização de Testes")]
        public void TesteUsandoParametrizacao(int valor, bool resultadoEsperado)
        {
            bool resultado = conta.Sacar(valor);

            Assert.IsFalse(resultadoEsperado);
        }

        #endregion

        #region Testando TimeOuts
        [Test]
        [Category("Testando TimeOut, falhando caso ele demore muito na execução")]
        [TestCase(false)]
        [Timeout(4000)] // tempo avaliado em milisegundos (4000 = 4 segs)
        //Se o NUnit passar de 4 segundos ele cancela o teste
        public void TesteTimeOut(bool resultadoEsperado)
        {
            Assert.IsFalse(resultadoEsperado);
        }
        #endregion
    }
}
