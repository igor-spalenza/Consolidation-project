using MarkdownMvcLibrary;
using System.Web.Mvc;

namespace CRM.Produto.Consolidacao.Apresentacao
{
    public partial class Projeto
    {
        private void ConfiguraRenderizadores() => ViewEngines.Engines.Add(new MarkdownViewEngine());
    }
}