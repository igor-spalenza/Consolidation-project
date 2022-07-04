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
    public class InscricaoDAO : IInscricaoDAO
    {
        public void Inserir(Inscricao inscricao)
        {
            using(var context = new ProjetoDataContext())
            {
                context.Inscricoes.Add(inscricao);
                context.SaveChanges();
            }
        }

        public List<Inscricao> Obter()
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                List<Inscricao> inscricoes = context.Inscricoes.ToList();
                foreach (var inscricao in inscricoes)
                {
                    inscricao.Curso = context.Cursos.Find(inscricao.CursoId);
                    inscricao.Pessoa = context.Pessoas.Find(inscricao.PessoaId);
                }
                return inscricoes;
            }
        }

        public Inscricao Encontrar(int id)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                Inscricao inscricao = context.Inscricoes.Find(id);
                inscricao.Curso = context.Cursos.Find(inscricao.CursoId);
                inscricao.Pessoa = context.Pessoas.Find(inscricao.PessoaId);
                inscricao.Curso.Concurso = context.Concursos.Find(inscricao.Curso.ConcursoId);
                return inscricao;
            }
        }

        public void Remover(int id)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                var inscricao = context.Inscricoes.Find(id);
                context.Inscricoes.Remove(inscricao);
                context.SaveChanges();
            }
        }

        //private Curso CursoInscricao(int id)
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        Curso curso = context.Cursos.Find(id);
        //        return curso;
        //    }
        //}
    }
}
