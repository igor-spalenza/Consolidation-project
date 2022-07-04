namespace CRM.Produto.Consolidacao.Dominio.Entidades
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Pessoa
    {
        public Pessoa()
        {
            DataCadastro = DateTime.Now;
        }

        public Pessoa(string nome, string cPF, string rG, string email, string telefone, DateTime dataNascimento, string cEP, string logradouro, int numero, string complemento, string bairro, string cidade, string estado)
        {
            Nome = nome;
            CPF = cPF;
            RG = rG;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            CEP = cEP;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            DataCadastro = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Preenchimento de nome obrigatório ")]
        [RegularExpression(@"^([\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+((\s[\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+)?$", ErrorMessage = "No campo Nome são válidos somente caracteres do tipo letras (A-Z)")]
        public string Nome { get; set; }


        //[RegularExpression(@"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$", ErrorMessage = "Número de CPF Inválido")]
        [Required(ErrorMessage = "Preenchimento de CPF obrigatório ")]
        public string CPF { get; set; }


        [Required(ErrorMessage = "Preenchimento de RG obrigatório ")]
        [DisplayName("RG (Apenas números)")]
        public string RG { get; set; }


        [Required(ErrorMessage = "Preenchimento de Email obrigatório ")]
        [DisplayName("E-mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Preenchimento de Telefone obrigatório ")]
        //[RegularExpression(@"^\(\d{2}\)\s\d{4}\-\d{4}$", ErrorMessage = "Número de telefone inválido.")]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "Preenchimento da Data de Nascimento obrigatório ")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }


        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }


        //[RegularExpression(@"/^([\d]{2})\.?([\d]{3})\-?([\d]{3})/", ErrorMessage = "Formato de CEP Inválido")]
        [Required(ErrorMessage = "Preenchimento de CEP obrigatório ")]
        [DisplayName("CEP (Código Postal)")]
        public string CEP { get; set; }


        [Required(ErrorMessage = "Preenchimento de Logradouro obrigatório ")]
        public string Logradouro { get; set; }


        [Required(ErrorMessage = "Preenchimento de Número obrigatório ")]
        //[MaxLength(5, ErrorMessage = "O campo Número só pode ter até 5 caracteres")]
        public int Numero { get; set; }
        

        public string Complemento { get; set; }
        

        [Required(ErrorMessage = "Preenchimento do campo Bairro obrigatório ")]
        public string Bairro { get; set; }
        

        [Required(ErrorMessage = "Preenchimento de Cidade obrigatório ")]
        public string Cidade { get; set; }
        

        [Required(ErrorMessage = "Preenchimento de UF obrigatório ")]
        public string Estado { get; set; }
    }
}