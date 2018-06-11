using System.Web.Http;
using WebActivatorEx;
using SimasoftCorp.DesafioStone.WebApi;
using Swashbuckle.Application;
using System.Reflection;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SimasoftCorp.DesafioStone.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory + @"\bin\";
                        var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                        var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                        c.SingleApiVersion("v1", "Desafio Stone 01 - Módulo Financeiro")
                            .Description("Desafio Stone 01 - Módulo Financeiro")                            
                            .Contact(cc => cc
                            .Name("Gabriel Simas")
                            .Url("https://www.linkedin.com/in/gabrielsimas/")
                            .Email("gabrielsimas@gmail.com"))
                            .License(lc => lc
                                .Name("MIT")
                                .Url("https://opensource.org/licenses/MIT"));

                        c.IncludeXmlComments(commentsFile);
                        c.IgnoreObsoleteActions();
                        c.DescribeAllEnumsAsStrings();
                    })
                .EnableSwaggerUi();
        }
    }
}
