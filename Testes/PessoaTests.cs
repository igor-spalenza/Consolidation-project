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
    /// Summary description for PessoaTests
    /// </summary>
    [TestClass]
    public class PessoaTests
    {
        [TestInitialize]
        public void setup()
        {
            Dependencias.Resolvedor = new Resolvedor();
        }

        private Exception exception = null;

        [TestMethod]
        public void InserirPessoaCompleta()
        {
            //Arranje
            using (var context = new ProjetoDataContext())
            {
                Pessoa pessoa = new Pessoa(
                    "Rick", "61736990012", "55552999", "teste@teste.com", "3134349242", DateTime.Now.AddDays(-50),
                    "31742302", "Rua sete", 5, "", "MAntiqueira", "Belo Horizonte", "MG");

                //Act
                try
                {
                    Dependencias.PessoaDAO.Inserir(pessoa);
                }
                catch (Exception e)
                {
                    exception = e;
                }

                //Assert
                Assert.IsNull(exception);

                context.Pessoas.Attach(pessoa);
                context.Pessoas.Remove(pessoa);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void InserirPessoaSemNome()
        {
            //Arranje
            using (var context = new ProjetoDataContext())
            {
                Pessoa pessoa = new Pessoa(
                    "", "61736991112", "55552999", "teste@teste.com", "3134349242", DateTime.Now.AddDays(-50),
                    "31742302", "Rua sete", 5, "", "MAntiqueira", "Belo Horizonte", "MG");

                //Act
                try
                {
                    Dependencias.PessoaDAO.Inserir(pessoa);
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
        public void ExcluirPessoa()
        {
            //Arranje
            using (var context = new ProjetoDataContext())
            {
                Pessoa pessoa = new Pessoa(
                    "Testando a exclusão de pessoa", "61736991112", "57552999", "teste@teste.com", "3134349242", DateTime.Now.AddDays(-50),
                    "31742302", "Rua sete", 5, "", "MAntiqueira", "Belo Horizonte", "MG");
                context.Pessoas.Add(pessoa);
                context.SaveChanges();

                //Act
                var pessoaReferencia = pessoa;

                context.Pessoas.Attach(pessoa);
                context.Pessoas.Remove(pessoa);
                context.SaveChanges();

                var checagem = context.Pessoas.Find(pessoaReferencia.Id);


                //Assert
                Assert.IsNull(checagem);
            }
        }
    }
}
