using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using SimasoftCorp.DesafioStone.Crosscutting.Mapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado;
using SimasoftCorp.DesafioStone.Infraestrutura.Entidades;

namespace Teste.DesafioStone.Crosscutting.Mapper
{
    /// <summary>
    /// Testa unitariamente as conversões utilizando o AutoMapper
    /// </summary>
    [TestClass]
    public class AutoMapperTeste
    {
        private TestContext testContextInstance;
        private readonly IMapper mapper;

        public AutoMapperTeste()
        {
            mapper = AutoMapperConfigFactory.GetMapper();
        }

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
        [TestCategory("Teste Unitário - Spike - Crosscutting - AutoMapper")]
        public void ClienteDtoParaCliente()
        {
            ClienteDto dto = new ClienteDto()
            {
                Cpf = "067.893.996-90",
                Nome = "Luís Gabriel Nascimento Simas",
                Estado = "RJ"
            };

            Cliente dominio = mapper.Map<Cliente>(dto);
            Assert.IsTrue(dominio.Cpf.Numero > 0);
        }

        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Crosscutting - AutoMapper")]
        public void ClienteParaClienteDto()
        {
            Cliente dominio = Cliente.NovoCliente(Cpf.Novo("067.893.996-90"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"));
            ClienteDto dto = mapper.Map<ClienteDto>(dominio);

            Assert.IsTrue(dto.Nome.Equals(dominio.Nome.Texto));
        }

        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Crosscutting - AutoMapper")]
        public void CobrancaDtoParaCobranca()
        {
            CobrancaDto dto = new CobrancaDto()
            {
                Cpf = "067.893.996-90",
                DataDeVencimento = DateTime.Now.AddDays(30),
                Valor = 150.00M
            };

            Cobranca dominio = mapper.Map<Cobranca>(dto);

            Assert.IsTrue(dominio.DataDeVencimento.DataContabil.Equals(dto.DataDeVencimento));
        }

        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Crosscutting - AutoMapper")]
        public void CobrancaParaCobrancaDto()
        {
            Cobranca dominio = Cobranca.NovaCobranca(150.00M, Data.Nova(DateTime.Now.AddDays(45)), Cpf.TrataCpf("067.893.996-90"));
            CobrancaDto dto = mapper.Map<CobrancaDto>(dominio);

            Assert.IsTrue(dto.Cpf.Equals(dominio.Cliente.Cpf.Numero.ToString()) && dto.DataDeVencimento.Equals(dominio.DataDeVencimento.DataContabil) && dto.Valor == dominio.Valor);
        }

        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Crosscutting - AutoMapper")]
        public void ClClienteParaCliente()
        {
            IList<ClCobranca> cobrancas = new List<ClCobranca>();

            cobrancas.Add(new ClCobranca() { Cpf = "067.893.996-90", DataDeVencimento = DateTime.Now.AddDays(15), Valor = 100.00M });
            cobrancas.Add(new ClCobranca() { Cpf = "067.893.996-90", DataDeVencimento = DateTime.Now.AddDays(30), Valor = 100.00M });
            cobrancas.Add(new ClCobranca() { Cpf = "067.893.996-90", DataDeVencimento = DateTime.Now.AddDays(45), Valor = 100.00M });
            cobrancas.Add(new ClCobranca() { Cpf = "067.893.996-90", DataDeVencimento = DateTime.Now.AddDays(60), Valor = 100.00M });
            cobrancas.Add(new ClCobranca() { Cpf = "067.893.996-90", DataDeVencimento = DateTime.Now.AddDays(75), Valor = 100.00M });
            cobrancas.Add(new ClCobranca() { Cpf = "067.893.996-90", DataDeVencimento = DateTime.Now.AddDays(90), Valor = 100.00M });
            cobrancas.Add(new ClCobranca() { Cpf = "067.893.996-90", DataDeVencimento = DateTime.Now.AddDays(105), Valor = 100.00M });
            cobrancas.Add(new ClCobranca() { Cpf = "067.893.996-90", DataDeVencimento = DateTime.Now.AddDays(120), Valor = 100.00M });
            cobrancas.Add(new ClCobranca() { Cpf = "067.893.996-90", DataDeVencimento = DateTime.Now.AddDays(135), Valor = 100.00M });

            ClCliente clCliente = new ClCliente()
            {
                Cpf = "067.893.996-90",
                Nome = "Luís Gabriel Nascimento Simas",
                Uf = "RJ",
                Cobrancas = new List<ClCobranca>()
            };

            clCliente.Cobrancas.AddRange(cobrancas);

            Cliente dominio = mapper.Map<Cliente>(clCliente);

            Assert.IsTrue(dominio.TotalizarCobrancas() == 900);
        }

        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Crosscutting - AutoMapper")]
        public void ClienteParaClCliente()
        {
            Cliente cliente = Cliente.NovoCliente(Cpf.Novo("067.893.996-90"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"));
            List<Cobranca> cobrancas = new List<Cobranca>();

            cobrancas.Add(Cobranca.NovaCobranca(100M, Data.Nova(DateTime.Now.AddDays(15))));
            cobrancas.Add(Cobranca.NovaCobranca(100M, Data.Nova(DateTime.Now.AddDays(30))));
            cobrancas.Add(Cobranca.NovaCobranca(100M, Data.Nova(DateTime.Now.AddDays(45))));
            cobrancas.Add(Cobranca.NovaCobranca(100M, Data.Nova(DateTime.Now.AddDays(60))));
            cobrancas.Add(Cobranca.NovaCobranca(100M, Data.Nova(DateTime.Now.AddDays(75))));
            cobrancas.Add(Cobranca.NovaCobranca(100M, Data.Nova(DateTime.Now.AddDays(90))));
            cobrancas.Add(Cobranca.NovaCobranca(100M, Data.Nova(DateTime.Now.AddDays(105))));
            cobrancas.Add(Cobranca.NovaCobranca(100M, Data.Nova(DateTime.Now.AddDays(120))));
            cobrancas.Add(Cobranca.NovaCobranca(100M, Data.Nova(DateTime.Now.AddDays(135))));
            cliente.AdicionarCobrancas(cobrancas);

            ClCliente clCliente = mapper.Map<ClCliente>(cliente);

            Assert.IsTrue(clCliente.Cobrancas.Count == 9, "Erro ao converter o objeto de Domínio Cliente para a Entidade Cliente");
        }

        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Crosscutting - AutoMapper")]
        public void CobrancaParaClCobranca()
        {
            Cliente cliente = Cliente.NovoCliente(Cpf.Novo("067.893.996-90"), Nome.Novo("Luís Gabriel Nascimento Simas"), Uf.Novo("RJ"));
            Cobranca dominio = Cobranca.NovaCobranca(1000M, Data.Nova(new DateTime(2020, 12, 31)), cliente);

            ClCobranca collectionCobranca = mapper.Map<ClCobranca>(dominio);

            Assert.IsTrue(collectionCobranca.Cpf.Equals("6789399690"), "Erro ao converter o objeto de Domínio Cobrança para a Entidade Cobranca");
        }

        [TestMethod]
        [TestCategory("Teste Unitário - Spike - Crosscutting - AutoMapper")]
        public void ClCobrancaParaCobranca()
        {
            ClCobranca cobrancaCollection = new ClCobranca()
            {
                Cpf = "067.893.996-90",
                DataDeVencimento = new DateTime(2020, 12, 31),
                Valor = 20000M                
            };

            Cobranca dominio = mapper.Map<Cobranca>(cobrancaCollection);

            Assert.IsTrue(true);
        }
    }
}
