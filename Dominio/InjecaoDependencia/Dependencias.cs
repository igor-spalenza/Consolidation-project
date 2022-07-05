using CRM.Produto.Consolidacao.Dominio.Infraestrutura;
using CRM.Produto.Consolidacao.Dominio.Infraestrutura.Configuracao;
using CRM.Produto.Consolidacao.Dominio.Infraestrutura.DAO;

namespace CRM.Produto.Consolidacao.Dominio.InjecaoDependencia
{
    public static class Dependencias
    {
        #region Resolvedor

        private static IResolvedor _resolvedor;

        public static IResolvedor Resolvedor
        {
            get
            {
                if (_resolvedor == null)
                    throw new ResolvedorNaoConfiguradoException();

                return _resolvedor;
            }

            set
            {
                _resolvedor = value;
            }
        }

        #endregion Resolvedor

        public static IConfiguracao Configuracao
        {
            get
            {
                return Resolvedor.Resolve<IConfiguracao>();
            }
        }
        public static ILog Log
        {
            get
            {
                return Resolvedor.Resolve<ILog>();
            }
        }

        public static IPessoaDAO PessoaDAO
        {
            get
            {
                return Resolvedor.Resolve<IPessoaDAO>();
            }
        }

        public static ICursoDAO CursoDAO
        {
            get
            {
                return Resolvedor.Resolve<ICursoDAO>();
            }
        }

        public static IConcursoDAO ConcursoDAO
        {
            get
            {
                return Resolvedor.Resolve<IConcursoDAO>();
            }
        }

        public static IInscricaoDAO InscricaoDAO
        {
            get
            {
                return Resolvedor.Resolve<IInscricaoDAO>();
            }
        }

    }
}