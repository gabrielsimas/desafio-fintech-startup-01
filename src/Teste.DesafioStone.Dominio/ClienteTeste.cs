using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado;

namespace Teste.DesafioStone.Dominio
{
    /// <summary>
    /// Summary description for ClienteTeste
    /// </summary>
    [TestClass]
    public class ClienteTeste
    {
        public ClienteTeste()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Domínio - Cliente")]
        public void CriaCliente()
        {
            Cliente gabrielSimas = Cliente.NovoCliente(Cpf.Novo("06789399690"),Nome.Novo("Luís Gabriel Nascimento Simas"),Uf.Novo("RJ"));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(10.30m, Data.Hoje()));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(100.45m, Data.Hoje()));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(10000.12m, Data.Hoje()));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(120.56m, Data.Hoje()));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(765.67m, Data.Hoje()));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(97.09m, Data.Hoje()));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(392.76m, Data.Hoje()));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(234.12m, Data.Hoje()));
            
            Assert.IsTrue(gabrielSimas.Cpf.Numero > 0, "Erro ao criar a entidade!");
        }
        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Domínio - Cliente")]
        public void CriaClienteComNavegabilidadeMutua()
        {
            Cliente gabrielSimas = Cliente.NovoCliente(Cpf.Novo("06789399690"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(10.30m, Data.Hoje(), Cliente.NovoCliente(Cpf.Novo("06789399690"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"))));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(100.45m, Data.Hoje(), Cliente.NovoCliente(Cpf.Novo("06789399690"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"))));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(10000.12m, Data.Hoje(), Cliente.NovoCliente(Cpf.Novo("06789399690"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"))));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(120.56m, Data.Hoje(), Cliente.NovoCliente(Cpf.Novo("06789399690"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"))));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(765.67m, Data.Hoje(), Cliente.NovoCliente(Cpf.Novo("06789399690"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"))));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(97.09m, Data.Hoje(), Cliente.NovoCliente(Cpf.Novo("06789399690"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"))));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(392.76m, Data.Hoje(), Cliente.NovoCliente(Cpf.Novo("06789399690"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"))));
            gabrielSimas.AdicionarCobranca(Cobranca.NovaCobranca(234.12m, Data.Hoje(), Cliente.NovoCliente(Cpf.Novo("06789399690"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"))));

            Assert.IsTrue(gabrielSimas.Cpf.Numero > 0, "Erro ao criar a entidade!");
        }
    }
}
