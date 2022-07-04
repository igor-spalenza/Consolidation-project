using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Dominio.Infraestrutura
{
    public interface ILog
    {
        void Erro(object erro);

        void Informacao(object informacao);
    }
}
