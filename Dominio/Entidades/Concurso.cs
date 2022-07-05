using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Dominio.Entidades
{
    public class Concurso
    {
        public Concurso()
        {
            DataCadastro = DateTime.Now;
        }

        public Concurso(string nome, string descricao, bool situacao, DateTime dataHoraInicio, string iE)
        {
            Nome = nome;
            Descricao = descricao;
            Situacao = situacao;
            DataHoraInicio = dataHoraInicio;
            IE = iE;
            DataCadastro = DateTime.Now;
        }

        public Concurso(int id, string nome, string descricao, bool situacao, DateTime dataHoraInicio, DateTime dataCadastro, string iE)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Situacao = situacao;
            DataHoraInicio = dataHoraInicio;
            DataCadastro = dataCadastro;
            IE = iE;
        }

        [Key]
        [Display(Name = "Código do Concurso")]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Nome do Concurso")]
        public string Nome { get; set; }
        

        [Required (ErrorMessage = "Campo de Descrição é de preenchimento obrigatório ")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        [Required]
        [Display(Name = "Concurso publicado")]
        public bool Situacao { get; set; }


        [Required (ErrorMessage = "Informe a data e hora de início das provas")]
        [Display(Name = "Data e hora de prova")]
        public DateTime DataHoraInicio { get; set; }


        [Display(Name = "Data e hora de cadastro do Concurso")]
        public DateTime DataCadastro { get; set; }      
        

        [Required]
        [Display(Name = "Instituição de Ensino")]
        public string IE { get; set; }


        public List<Curso> Cursos { get; set; }
    }
}
