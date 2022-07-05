using CRM.Produto.Consolidacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class InscricaoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preenchimento de nome obrigatório ")]
        public int PessoaId { get; set; }


        [Required(ErrorMessage = "Preenchimento de nome obrigatório ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preenchimento de CPF obrigatório ")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preenchimento de RG obrigatório ")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Preenchimento de Email obrigatório ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preenchimento de Email obrigatório ")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preenchimento da Data de Nascimento obrigatório ")]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "Preenchimento de CEP obrigatório ")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Preenchimento de CEP obrigatório ")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Preenchimento de Número obrigatório ")]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Preenchimento do campo Bairro obrigatório ")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preenchimento de Cidade obrigatório ")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preenchimento de Estado obrigatório ")]
        public string Estado { get; set; }










        [Required(ErrorMessage = "Preenchimento de CPF obrigatório ")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "Preenchimento de RG obrigatório ")]
        public string Modalidade { get; set; }

        [Required(ErrorMessage = "Preenchimento de Email obrigatório ")]
        public string DataCadastro { get; set; }

    }
}