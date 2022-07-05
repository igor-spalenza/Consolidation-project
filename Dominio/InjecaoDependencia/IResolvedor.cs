namespace CRM.Produto.Consolidacao.Dominio.InjecaoDependencia
{
    public interface IResolvedor
    {
        T Resolve<T>();
    }
}