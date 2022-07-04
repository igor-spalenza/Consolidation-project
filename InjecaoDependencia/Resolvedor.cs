using CRM.Produto.Consolidacao.Dominio.Infraestrutura;
using CRM.Produto.Consolidacao.Dominio.Infraestrutura.Configuracao;
using CRM.Produto.Consolidacao.Dominio.Infraestrutura.DAO;
using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using CRM.Produto.Consolidacao.Infraestrutura;
using CRM.Produto.Consolidacao.Infraestrutura.Configuracao;
using CRM.Produto.Consolidacao.Infraestrutura.DAO;
using Unity;
using Unity.Lifetime;

namespace CRM.Produto.Consolidacao.InjecaoDependencia
{
    public sealed class Resolvedor : IResolvedor
    {
        private readonly IUnityContainer _container;

        public Resolvedor()
        {
            _container = new UnityContainer();

            //Aqui vai iniciar os Singleton das dependências
            Singleton<IConfiguracao>(Configuracao.Le());
            Singleton<ILog, Log>();
            Singleton<IPessoaDAO, PessoaDAO>();
            Singleton<ICursoDAO, CursoDAO>();
            Singleton<IConcursoDAO, ConcursoDAO>();
            Singleton<IInscricaoDAO, InscricaoDAO>();


        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private void Singleton<T>(T obj)
        {
            _container.RegisterInstance<T>(obj);
        }

        private void Singleton<T1, T2>() where T2 : T1
        {
            _container.RegisterType<T1, T2>(new ContainerControlledLifetimeManager());
        }
    }
}