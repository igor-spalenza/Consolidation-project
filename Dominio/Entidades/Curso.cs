    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Dominio.Entidades
{
    public class Curso
    {
        public Curso()
        {
            DataCadastro = DateTime.Now;
        }

        public Curso(string nome, string descricao, int capacidade, int cargaHoraria, int concursoId)
        {
            Nome = nome;
            Descricao = descricao;
            Capacidade = capacidade;
            CargaHoraria = cargaHoraria;
            ConcursoId = concursoId;
            DataCadastro = DateTime.Now;
        }

        public Curso(string nome, string descricao, int capacidade, int cargaHoraria, Concurso concurso)
        {
            DataCadastro = DateTime.Now;
            Nome = nome;
            Descricao = descricao;
            Capacidade = capacidade;
            CargaHoraria = cargaHoraria;
            Concurso = concurso;
        }

        public Curso(int id, string nome, string descricao, int capacidade, int cargaHoraria, DateTime dataCadastro, int concursoId)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Capacidade = capacidade;
            CargaHoraria = cargaHoraria;
            DataCadastro = dataCadastro;
            ConcursoId = concursoId;
        }

        [Key]
        public int Id { get; set; }


        [Display(Name = "Nome do curso ofertado")]
        [Required]
        public string Nome { get; set; }
        

        [Required]
        [Display(Name = "Descrição do curso")]
        public string Descricao { get; set; }
        

        [Display(Name = "Quantidade de vagas")]
        [Required]
        public int Capacidade { get; set; }
        

        [Display(Name = "Carga horária total do curso")]
        [Required]
        public int CargaHoraria { get; set; }


        [Display(Name = "Data e hora de cadastro")]
        public DateTime DataCadastro { get; set; }
        

        [Required]
        public int ConcursoId { get; set; }
        

        public Concurso Concurso { get; set; }

    }
}
