using CRM.Produto.Consolidacao.Dominio.Entidades;
using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using CRM.Produto.Consolidacao.Infraestrutura.EntityContext;
using CRM.Produto.Consolidacao.InjecaoDependencia;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testes
{
    /// <summary>
    /// Summary description for InscricaoTests
    /// </summary>
    [TestClass]
    public class InscricaoTests
    {
        [TestInitialize]
        public void setup()
        {
            Dependencias.Resolvedor = new Resolvedor();
        }

        private Exception exception = null;

        [TestMethod]
        public void InserirInscricaoCompleta()
        {
            //Arranje
            using (var context = new ProjetoDataContext())
            {
                Pessoa pessoa = new Pessoa(
                    "Rick", "57312511447", "22552989", "teste@teste.com", "3134349242", DateTime.Now.AddDays(50),
                    "31742302","Rua sete", 5, "", "MAntiqueira", "Belo Horizonte", "MG");
                context.Pessoas.Add(pessoa);
                Curso curso = new Curso("Medicina", "Lorem Ipsum ", 300, 5000, 
                    new Concurso("Vestibular teste", "bla bla bla lalalal", false, DateTime.Now.AddDays(50), "Unifenas"));
                context.Cursos.Add(curso);
                context.SaveChanges();

                Inscricao inscricao = new Inscricao(pessoa.Id, curso.Id, "2ª graduação");

                //Act
                try
                {
                    Dependencias.InscricaoDAO.Inserir(inscricao);
                }
                catch (Exception e)
                {
                    exception = e;
                }

                //Assert
                Assert.IsNull(exception);
                exception = null;

                context.Inscricoes.Attach(inscricao);
                context.Inscricoes.Remove(inscricao);
                context.Pessoas.Remove(pessoa);
                context.Concursos.Remove(context.Concursos.Find(curso.ConcursoId));
                context.Cursos.Remove(curso);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InserirInscricaoSemModalidade()
        {
            //Arranje
            using (var context = new ProjetoDataContext())
            {
                Pessoa pessoa = new Pessoa(
                    "Rick", "57112511007", "22552199", "teste@teste.com", "3134349242", DateTime.Now.AddDays(50),
                    "31742302", "Rua sete", 5, "", "MAntiqueira", "Belo Horizonte", "MG");
                context.Pessoas.Add(pessoa);
                Curso curso = new Curso("Medicina", "Lorem Ipsum ", 300, 5000,
                    new Concurso("Vestibular teste", "bla bla bla lalalal", false, DateTime.Now.AddDays(50), "Unifenas"));
                context.Cursos.Add(curso);
                context.SaveChanges();

                Inscricao inscricao = new Inscricao(pessoa.Id, curso.Id, "");

                //Act
                try
                {
                    Dependencias.InscricaoDAO.Inserir(inscricao);
                }
                catch (Exception e)
                {
                    exception = e;
                }

                //Assert
                Assert.IsNotNull(exception);

                context.Pessoas.Remove(pessoa);
                context.Concursos.Remove(context.Concursos.Find(curso.ConcursoId));
                context.Cursos.Remove(curso);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void ExcluirInscricao()
        {
            //Arranje
            using (var context = new ProjetoDataContext())
            {
                Pessoa pessoa = new Pessoa(
                    "Rick", "38965429088", "34888638", "teste@teste.com", "3134349242", DateTime.Now.AddDays(-5050),
                    "31742302", "Rua sete", 5, "", "MAntiqueira", "Belo Horizonte", "MG");
                context.Pessoas.Add(pessoa);
                Curso curso = new Curso("Medicina", "Lorem Ipsum ", 300, 5000,
                    new Concurso("Vestibular teste", "bla bla bla lalalal", false, DateTime.Now.AddDays(50), "Unifenas"));
                context.Cursos.Add(curso);
                context.SaveChanges();

                Inscricao inscricao = new Inscricao(pessoa.Id, curso.Id, "2ª graduação");

                Dependencias.InscricaoDAO.Inserir(inscricao);

                //Act
                var inscricaoReferencia = inscricao;

                context.Inscricoes.Attach(inscricao);
                context.Inscricoes.Remove(inscricao);
                context.SaveChanges();

                var checagem = context.Inscricoes.Find(inscricaoReferencia.Id);

                //Assert
                Assert.IsNull(checagem);

                context.Pessoas.Remove(pessoa);
                context.Concursos.Remove(context.Concursos.Find(curso.ConcursoId));
                context.Cursos.Remove(curso);
                context.SaveChanges();
            }
        }




    }
}
