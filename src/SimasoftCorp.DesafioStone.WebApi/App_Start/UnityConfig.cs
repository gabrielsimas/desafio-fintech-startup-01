using SimasoftCorp.DesafioStone.Infraestrutura.Containers.IoC.MSUnity;
using System;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace SimasoftCorp.DesafioStone.WebApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            ContainerDoUnity.InicializaContainer(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}