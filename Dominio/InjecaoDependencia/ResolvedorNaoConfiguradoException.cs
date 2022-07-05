using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Dominio.InjecaoDependencia
{
    public class ResolvedorNaoConfiguradoException : Exception
    {
        public ResolvedorNaoConfiguradoException() :
            base($"Nenhuma instância de {typeof(IResolvedor).Name} foi configurada no domínio")
        {
        }
    }
}
