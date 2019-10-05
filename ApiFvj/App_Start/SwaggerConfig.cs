using System.Web.Http;
using WebActivatorEx;
using ApiFvj;
using Swashbuckle.Application;
using System;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ApiFvj
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "ApiFvj");

                        c.IgnoreObsoleteActions();
                        c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\ApiFvj.xml");
                        c.IgnoreObsoleteProperties();

                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("Documentação API");
                        c.DocExpansion(DocExpansion.List);
                    });
        }
    }
}
