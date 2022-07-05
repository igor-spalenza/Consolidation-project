using CRM.Produto.Consolidacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Dominio.Infraestrutura.DAO
{
    public interface ICursoDAO
    {
        void Inserir(Curso curso);
        List<Curso> Obter();
        Curso Encontrar(int id);
        List<Concurso> ConcursosAtivos();
        bool VerificaConcursoPublicado(int concursoId);
        bool PossuiInscricao(int cursoId);
        void Editar(Curso curso);
        void Remover(int id);
    }
}
