using CRM.Produto.Consolidacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Dominio.Infraestrutura.DAO
{
    public interface IInscricaoDAO
    {
        void Inserir(Inscricao incricao);

        List<Inscricao> Obter();
        
        Inscricao Encontrar(int id);

        //void Editar(Concurso concurso);
        
        void Remover(int id);
    }
}
