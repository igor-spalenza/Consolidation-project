using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CRM.Produto.Consolidacao.Apresentacao
{
    public partial class Projeto
    {
        protected void Application_Start()
        {
            ConfiguracaoInjecaoDependencia();
            ConfigurarBundles(BundleTable.Bundles);
            ConfiguraFiltros(GlobalFilters.Filters);
            ConfiguraRenderizadores();
            ConfiguraRotas(RouteTable.Routes);
            Dependencias.Log.Informacao("A aplicação foi iniciada!");
        }
    }
}