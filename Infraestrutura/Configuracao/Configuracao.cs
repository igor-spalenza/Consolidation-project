using CRM.Produto.Consolidacao.Dominio.Infraestrutura.Configuracao;
using ObjectLibrary;
using System.Configuration;

namespace CRM.Produto.Consolidacao.Infraestrutura.Configuracao
{
    public class Configuracao : IConfiguracao
    {
        public static Configuracao Le()
        {
            return ConfigurationManager.AppSettings.ToObjectSafe<Configuracao>();
        }
    }
}