using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Produto.Consolidacao.Apresentacao.Controllers
{
    public class InscricaoController : Controller
    {
        private string FormataCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        private string FormataTelefone(string telefone)
        {
            return Convert.ToUInt64(telefone).ToString(@"\(00\)00000\-0000");
        }


        public ActionResult Index()
        {
            return View(Dependencias.InscricaoDAO.Obter());
        }

        public ActionResult Detalhar(int id)
        {
            var inscricao = Dependencias.InscricaoDAO.Encontrar(id);
            inscricao.Pessoa.CPF = FormataCPF(inscricao.Pessoa.CPF);
            inscricao.Pessoa.Telefone = FormataTelefone(inscricao.Pessoa.Telefone);
            return View(inscricao);
        }
    }
}
