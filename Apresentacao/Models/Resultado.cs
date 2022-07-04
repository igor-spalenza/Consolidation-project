using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Produto.Consolidacao.Apresentacao.Models
{
    public class Resultado
    {
        public Resultado(bool status, string message)
        {
            Status = status;
            Message = message;
        }

        public bool Status { get; set; }

        public string Message { get; set; }
    }
}