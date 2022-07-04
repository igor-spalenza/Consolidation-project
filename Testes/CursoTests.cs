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
    /// Summary description for CursoTests
    /// </summary>
    [TestClass]
    public class CursoTests
    {
        private Exception exception = null;


        [TestMethod]
        public void ExcluirCurso()
        {
            //Arranje
            using (var context = new ProjetoDataContext())
            {
                Dependencias.Resolvedor = new Resolvedor();

                Curso curso = new Curso("Medicina",
                    "Lorem Ipsum ",
                    300,
                    5000,
                    new Concurso(
                        "Vestibular teste",
                        "bla bla bla lalalal",
                        false, DateTime.Now.AddDays(50),
                        "Unifenas"));
                context.Cursos.Add(curso);
                context.SaveChanges();


                //Act
                var cursoReferencia = curso;

                context.Cursos.Attach(curso);
                context.Cursos.Remove(curso);
                context.SaveChanges();

                var checagem = context.Pessoas.Find(curso.Id);


                //Assert
                Assert.IsNull(checagem);
            }
        }
        [TestMethod]
        public void InserirCursoCompleto()
        {
            //Arranje
            Dependencias.Resolvedor = new Resolvedor();
            using (var context = new ProjetoDataContext())
            {
                Concurso concurso = new Concurso(
                    "Vestibular teste", "bla bla bla lalalal", false, DateTime.Now.AddDays(50), "Unifenas");
                context.Concursos.Add(concurso);
                context.SaveChanges();
                
                Curso curso = new Curso("Medicina", "Lorem Ipsum ", 300, 5000, concurso.Id);

                //Act
                try
                {
                    Dependencias.CursoDAO.Inserir(curso);
                }
                catch (Exception e)
                {
                    exception = e;
                }

                //Assert
                Assert.IsNull(exception);
                exception = null;
            }
        }


        [TestMethod]
        public void InserirCursoSemDescricao()
        {
            //Arranje
            Dependencias.Resolvedor = new Resolvedor();
            using (var context = new ProjetoDataContext())
            {
                Concurso concurso = new Concurso(
                    "Vestibular teste", "Testando", false, DateTime.Now.AddDays(200), "Unifenas");
                context.Concursos.Add(concurso);
                context.SaveChanges();

                Curso curso = new Curso("Medicina", "", 300, 5000, concurso.Id);

                //Act
                try
                {
                    Dependencias.CursoDAO.Inserir(curso);
                }
                catch (Exception e)
                {
                    exception = e;
                }

                //Assert
                Assert.IsNotNull(exception);

                context.Concursos.Attach(concurso);
                context.Concursos.Remove(concurso);
                context.SaveChanges();
            }
        }


        [TestMethod]
        public void AlterarCurso()
        {
            //Arranje
            Dependencias.Resolvedor = new Resolvedor();
            using (var context = new ProjetoDataContext())
            {
                Curso curso = new Curso(
                    "Medicina",
                    "Lorem Ipsum ",
                    300,
                    5000,
                    new Concurso(
                        "Vestibular teste",
                        "bla bla bla lalalal",
                        false, DateTime.Now.AddDays(50),
                        "Unifenas"));
                context.Cursos.Add(curso);
                context.SaveChanges();

                //Act
                var cursoReferencia = curso;
                var cursoNovo = new Curso(
                    curso.Id, 
                    "Novo nome", 
                    "Nova descrição",
                    520, 
                    7000,
                    curso.DataCadastro,
                    curso.ConcursoId);

                Dependencias.CursoDAO.Editar(cursoNovo);

                //Assert
                Assert.AreNotEqual(cursoNovo, cursoReferencia);
            }
        }


    }
}
