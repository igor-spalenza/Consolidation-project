using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InscricaoExterna.Models
{
    public class InscricaoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preenchimento de nome obrigatório ")]
        public string PessoaId { get; set; }


        [Required(ErrorMessage = "Preenchimento de nome obrigatório ")]
        [RegularExpression(@"^([\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+((\s[\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+)?$", ErrorMessage = "No campo Nome são válidos somente caracteres do tipo letras (A-Z)")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "Preenchimento de CPF obrigatório ")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preenchimento de RG obrigatório ")]
        [DisplayName("RG (Apenas números)")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Preenchimento de E-mail obrigatório ")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preenchimento de Telefone para contato obrigatório ")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preenchimento da Data de Nascimento obrigatório ")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preenchimento de CEP obrigatório ")]
        [DisplayName("CEP (Código Postal)")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Preenchimento de Logradouro obrigatório ")]
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




        [Required(ErrorMessage = "É necessário escolher um Curso para confirmar sua inscrição")]
        public string CursoId { get; set; }

        [Required(ErrorMessage = "Escolha a modalidade de ingresso ")]
        [DisplayName("Modalidade de ingresso")]
        public string Modalidade { get; set; }

        public string DataCadastro { get; set; }

    }
}