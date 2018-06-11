using SimasoftCorp.DesafioStone.Dominio.Financeiro.Contratos.Repositorio;
using SimasoftCorp.DesafioStone.Dominio.Financeiro.Contratos.Servico;
using SimasoftCorp.DesafioStone.Dominio.Financeiro.Servico;
using SimasoftCorp.DesafioStone.Infraestrutura.Repositorio;
using Unity;
using Unity.Injection;

namespace SimasoftCorp.DesafioStone.Infraestrutura.Containers.IoC.MSUnity
{
    public class ContainerDoUnity
    {
        #region Atributos
        static IUnityContainer container;
        #endregion

        #region Construtores
        static ContainerDoUnity()
        {
            //CriaContainer();
        }

        #endregion

        #region Propriedades
        public static IUnityContainer Container
        {
            get
            {
                return container;
            }

            set
            {
                container = value;
            }
        }
        #endregion

        #region Injeção de Dependências
        static void CriaContainer(IUnityContainer container)
        {
            //Eu bem que poderia usar o método automático do Unity, mas não confio na 'Máquina' tanto assm
            //Prefiro controlar manualmente cada injeção.
            //Dá mais trabalho...dá! porém, a manutenção fica mais centralizada e se algo der errado nos testes
            //saberemos onde corrigir.

            //Repositorios
            //container.RegisterType<DbContext, Conexao>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>(new InjectionConstructor(container.Resolve<Conexao>()));
            //container.RegisterType<ITarefaRepositorio, TarefaRepositorio>(new InjectionConstructor(container.Resolve<Conexao>()));
           // container.RegisterType<ICobrancaRepositorio, CobrancaRepositorio>();
            //container.RegisterType<IClienteRepositorio, ClienteRepositorio>();

            //Servicos de Domínio            
            //container.RegisterType<IFinanceiroServicoDominio, FinanceiroServicoDominio>(new InjectionConstructor(container.Resolve<IClienteRepositorio>()));
            //container.RegisterType<ICobrancaServicoDominio, CobrancaServicoDominio>(new InjectionConstructor(container.Resolve<ICobrancaRepositorio>()));

            //Aplicação            
            //container.RegisterType<IUsuarioAplicServico, UsuarioAplicServico>(new InjectionConstructor(container.Resolve<IUsuarioServicoDominio>()));
            //container.RegisterType<ITarefaAplicServico, TarefaAplicServico>(new InjectionConstructor(container.Resolve<ITarefaServicoDominio>()));
            //container.RegisterType<IClienteAplicacao, ClienteAplicacaoServico>(new InjectionConstructor(container.Resolve<IClienteServicoDominio>()));
            //container.RegisterType<ICobrancaAplicacao, CobrancaAplicacaoServico>(new InjectionConstructor(container.Resolve<ICobrancaServicoDominio>()));
        }

        public static void InicializaContainer(IUnityContainer containerInjetado)
        {
            CriaContainer(containerInjetado);
        }

        #endregion
    }
}
