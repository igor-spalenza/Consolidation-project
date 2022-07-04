using CRM.Produto.Consolidacao.Dominio.Entidades;
using CRM.Produto.Consolidacao.Dominio.Infraestrutura.DAO;
using CRM.Produto.Consolidacao.Infraestrutura.EntityContext;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Produto.Consolidacao.Infraestrutura.DAO
{
    public class PessoaDAO : IPessoaDAO
    {
        public Pessoa BuscarCPF(string cpf)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                cpf = ReplaceCPF(cpf);
                var pessoaConsulta = context.Pessoas.Where(p => p.CPF == cpf);
                Pessoa pessoa = pessoaConsulta.FirstOrDefault();
                return pessoa;
            }
        }

        public void Editar(Pessoa pessoa)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                pessoa.CPF = ReplaceCPF(pessoa.CPF);
                pessoa.CEP = ReplaceCPF(pessoa.CEP);
                pessoa.Telefone = ReplaceTelefone(pessoa.Telefone);

                var pessoaEditada = context.Pessoas.Find(pessoa.Id);
                context.Entry(pessoaEditada).CurrentValues.SetValues(pessoa);
                context.Entry(pessoaEditada).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Pessoa Encontrar(int id)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                return context.Pessoas.Find(id);
            }
        }

        public void Inserir(Pessoa pessoa)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                pessoa.CPF = ReplaceCPF(pessoa.CPF);
                pessoa.CEP = ReplaceCPF(pessoa.CEP);
                pessoa.Telefone = ReplaceTelefone(pessoa.Telefone);
                context.Pessoas.Add(pessoa);
                context.SaveChanges();
            }
        }

        public List<Pessoa> Obter()
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                return context.Pessoas.ToList();
            }
        }

        public void Remover(Pessoa pessoa)
        {
            using (ProjetoDataContext context = new ProjetoDataContext())
            {
                context.Pessoas.Remove(pessoa);
                context.SaveChanges();
            }
        }

        private string ReplaceCPF(string cpf)
        {
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");
            return cpf;
        }

        private string ReplaceTelefone(string cep)
        {
            cep = cep.Replace("-", "");
            cep = cep.Replace("(", "");
            cep = cep.Replace(")", "");
            cep = cep.Replace(" ", "");
            return cep;
        }
    }
}