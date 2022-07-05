using CRM.Produto.Consolidacao.Dominio.Infraestrutura;
using LLibrary;
using System;

namespace CRM.Produto.Consolidacao.Infraestrutura
{
    public class Log : ILog
    {
        private readonly L _logger = new L(deleteOldFiles: TimeSpan.FromDays(15));

        public void Dispose()
        {
            _logger.Dispose();
        }

        public void Erro(object erro)
        {
            _logger.Error(erro);
        }

        public void Informacao(object informacao)
        {
            _logger.Info(informacao);
        }
    }
}