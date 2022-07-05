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
    /// Summary description for ConcursoTests
    /// </summary>
    [TestClass]
    public class ConcursoTests
    {
        private Exception exception = null;

        [TestMethod]
        public void InserirConcursoCompleto()
        {
            //Arranje
            Dependencias.Resolvedor = new Resolvedor();
            using (var context = new ProjetoDataContext())
            {
                Concurso concurso = new Concurso(
                    "Vestibular teste", "bla bla bla lalalal", false, DateTime.Now.AddDays(100), "Unifenas");

                //Act
                try
                {
                    Dependencias.ConcursoDAO.Inserir(concurso);
                }
                catch (Exception e)
                {
                    exception = e;
                }

                //Assert
                Assert.IsNull(exception);
                exception = null;

                context.Concursos.Attach(concurso);
                context.Concursos.Remove(concurso);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InserirConcursoSemNome()
        {
            //Arranje
            Dependencias.Resolvedor = new Resolvedor();
            using (var context = new ProjetoDataContext())
            {
                Concurso concurso = new Concurso("", "bla bla bla lalalal", false, DateTime.Now.AddDays(100), "Unifenas");

                //Act
                try
                {
                    Dependencias.ConcursoDAO.Inserir(concurso);
                }
                catch (Exception e)
                {
                    exception = e;
                }

                //Assert
                Assert.IsNotNull(exception);
            }
        }

        [TestMethod]
        public void ExcluirConcurso()
        {
            //Arranje
            Dependencias.Resolvedor = new Resolvedor();
            using (var context = new ProjetoDataContext())
            {
                Concurso concurso = new Concurso(
                    "Vestibular teste", "bla bla bla lalalal", false, DateTime.Now.AddDays(100), "Unifenas");
                Dependencias.ConcursoDAO.Inserir(concurso);

                //Act
                var concursoReferencia = concurso;
                context.Concursos.Attach(concurso);
                context.Concursos.Remove(concurso);
                context.SaveChanges();

                var query = context.Concursos.Find(concursoReferencia.Id);

                //Assert
                Assert.IsNull(query);
            }
        }

        [TestMethod]
        public void AlterarConcurso()
        {
            //Arranje
            Dependencias.Resolvedor = new Resolvedor();
            using (var context = new ProjetoDataContext())
            {
                Concurso concurso = new Concurso("Vestibular teste", "bla bla bla lalalal", false, DateTime.Now.AddDays(100), "Unifenas");
                Dependencias.ConcursoDAO.Inserir(concurso);

                //Act
                var concursoReferencia = concurso;
                var concursoNovo = new Concurso(concurso.Id, "Novo valor", "New value", true, DateTime.Now.AddDays(50), concurso.DataCadastro, "Unifenas");
                Dependencias.ConcursoDAO.Editar(concursoNovo);

                //Assert
                Assert.AreNotEqual(concursoNovo, concursoReferencia);
            }
        }


    }
}
