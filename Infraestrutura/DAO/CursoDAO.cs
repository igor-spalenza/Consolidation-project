using CRM.Produto.Consolidacao.Dominio.Entidades;
using CRM.Produto.Consolidacao.Dominio.Infraestrutura.DAO;
using CRM.Produto.Consolidacao.Infraestrutura.EntityContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Infraestrutura.DAO
{
    public class CursoDAO : ICursoDAO
    {

        public List<Concurso> ConcursosAtivos()
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                return context.Concursos.Where(cc => cc.Situacao == true).ToList();
            }
        }

        public void Editar(Curso cursoNovo)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                var cursoEditado = context.Cursos.Find(cursoNovo.Id);
                context.Entry(cursoEditado).CurrentValues.SetValues(cursoNovo);
                context.Entry(cursoEditado).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Curso Encontrar(int id)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {

                return context.Cursos.Find(id);
            }
        }

        public void Inserir(Curso curso)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                context.Cursos.Add(curso);
                context.SaveChanges();
            }
        }

        public List<Curso> Obter()
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                List<Curso> cursos = context.Cursos.ToList();
                foreach (var curso in cursos)
                {
                    curso.Concurso = context.Concursos.Find(curso.ConcursoId);
                }
                return cursos;
            }
        }

        public void Remover(int id)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                var curso = context.Cursos.Find(id);
                context.Cursos.Remove(curso);
                context.SaveChanges();
            }
        }

        public bool VerificaConcursoPublicado(int concursoId)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                Concurso concurso = context.Concursos.Find(concursoId);
                return concurso.Situacao;
            }
        }

        public bool PossuiInscricao(int cursoId)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                var inscricoes = context.Inscricoes.Where(i => i.CursoId == cursoId);
                return (inscricoes.Count() == 0 ? false : true);
            }
        }
    }
}
