using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Produto.Consolidacao.Apresentacao
{
    public partial class Projeto
    {
        protected void Application_End()
        {
            Dependencias.Log.Informacao("Aplicação encerrada.");
        }
    }
}