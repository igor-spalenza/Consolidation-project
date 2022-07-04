using CRM.Produto.Consolidacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Dominio.Infraestrutura.DAO
{
    public interface IPessoaDAO
    {
        void Inserir(Pessoa pessoa);
        List<Pessoa> Obter();
        Pessoa Encontrar(int id);
        void Editar(Pessoa pessoa);
        void Remover(Pessoa pessoa);

        Pessoa BuscarCPF(string cpf);

    }
}
