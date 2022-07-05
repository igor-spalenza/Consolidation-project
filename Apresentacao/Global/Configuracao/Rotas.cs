using System.Web.Mvc;
using System.Web.Routing;

namespace CRM.Produto.Consolidacao.Apresentacao
{
    public partial class Projeto
    {
        public static void ConfiguraRotas(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}