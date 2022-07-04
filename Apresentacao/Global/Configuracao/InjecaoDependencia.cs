using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using CRM.Produto.Consolidacao.InjecaoDependencia;

namespace CRM.Produto.Consolidacao.Apresentacao
{
    public partial class Projeto
    {
        private void ConfiguracaoInjecaoDependencia()
        {
            Dependencias.Resolvedor = new Resolvedor();
        }
    }
}