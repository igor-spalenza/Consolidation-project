using System.Web.Optimization;

namespace CRM.Produto.Consolidacao.Apresentacao
{
    public partial class Projeto
    {
        public static void ConfigurarBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.mask.js"));

            bundles.Add(new ScriptBundle("~/bundles/Pessoa").Include(
                        "~/Scripts/Pessoa/Pessoa.js"));

            bundles.Add(new ScriptBundle("~/bundles/Curso").Include(
                        "~/Scripts/Curso/Curso.js"));

            bundles.Add(new ScriptBundle("~/bundles/Concurso").Include(
                        "~/Scripts/Curso/Concurso.js"));

            bundles.Add(new ScriptBundle("~/bundles/Inscricao").Include(
            "~/Scripts/Curso/Concurso.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}