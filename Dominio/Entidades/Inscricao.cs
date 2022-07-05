using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Produto.Consolidacao.Dominio.Entidades
{
    public class Inscricao
    {
        public Inscricao()
        {
            DataCadastro = DateTime.Now;
        }

        public Inscricao(int pessoaId, int cursoId, string modalidade)
        {
            PessoaId = pessoaId;
            CursoId = cursoId;
            Modalidade = modalidade;
            DataCadastro = DateTime.Now;
        }

        [Key]
        [Display(Name = "Código de Inscrição")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Modalidade da Inscrição")]
        public string Modalidade { get; set; }
        

        [Required]
        public int CursoId { get; set; }

        [Display(Name = "Curso Inscrito")]
        public Curso Curso { get; set; }


        [Required]
        public int PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }

        [Display(Name = "Data e hora de Inscrição")]
        public DateTime DataCadastro { get; set; }
    }
}
