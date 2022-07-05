using CRM.Produto.Consolidacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Dominio.Infraestrutura.DAO
{
    public interface IConcursoDAO
    {
        void Inserir(Concurso concurso);
        List<Concurso> Obter();
        List<Concurso> BuscarConcursosPublicados();
        List<Curso> CursosDesteConcurso(int id);
        Concurso Encontrar(int id);
        void Editar(Concurso concurso);
        void Remover(int id);
        bool PossuiCurso(int concursoId);
    }
}
