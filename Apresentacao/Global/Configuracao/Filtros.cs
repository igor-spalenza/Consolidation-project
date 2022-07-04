using System.Web.Mvc;

namespace CRM.Produto.Consolidacao.Apresentacao
{
    public partial class Projeto
    {
        public static void ConfiguraFiltros(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}