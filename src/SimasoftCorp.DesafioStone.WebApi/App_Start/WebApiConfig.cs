using System.Web.Http;

namespace SimasoftCorp.DesafioStone.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //Habilita CORS global com permissão apenas para get,post
            //EnableCorsAttribute cors = new EnableCorsAttribute("*","*","get,post");
            //config.EnableCors

            //Bootstrap dp Unity configurado
            //Ele instala muita configuração via NuGet
            //Converti duas classes em uma!
            //Muito mais prático para centralizar a informação
            //E facilitar a manutenção
            UnityConfig.RegisterComponents();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
