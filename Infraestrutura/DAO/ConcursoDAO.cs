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
    public class ConcursoDAO : IConcursoDAO
    {
        public List<Concurso> BuscarConcursosPublicados()
        {
            {
                using (ProjetoDataContext context = new ProjetoDataContext())
                {
                    List<Concurso> concursos = new List<Concurso>();
                    var query = context.Concursos.Where(c => c.Situacao == true);
                    foreach (var concurso in query)
                    {
                        concursos.Add(concurso);
                    }
                    return concursos;
                }
            }

        }

        public void Editar(Concurso concursoNovo)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                var concursoEditado = context.Concursos.Find(concursoNovo.Id);
                context.Entry(concursoEditado).CurrentValues.SetValues(concursoNovo);
                context.Entry(concursoEditado).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Concurso Encontrar(int id)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                Concurso concurso = context.Concursos.Find(id);
                concurso.Cursos = CursosDesteConcurso(concurso.Id);

                return concurso;
            }
        }

        public List<Curso> CursosDesteConcurso(int id)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                List<Curso> cursos = new List<Curso>();
                var query = context.Cursos.Where(c => c.ConcursoId == id).ToList();
                foreach (var curso in query)
                {
                    cursos.Add(curso);
                }
                return cursos;
            }
        }

        public void Inserir(Concurso concurso)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                context.Concursos.Add(concurso);
                context.SaveChanges();
            }
        }

        public List<Concurso> Obter()
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                return context.Concursos.ToList();
            }
        }

        public void Remover(int id)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                var concurso = context.Concursos.Find(id);
                context.Concursos.Remove(concurso);
                context.SaveChanges();
            }
        }

        public bool PossuiCurso(int concursoId)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                var cursos = context.Cursos.Where(c => c.ConcursoId == concursoId);
                return (cursos.Count() != 0 ? true : false);
            }
        }
    }
}
