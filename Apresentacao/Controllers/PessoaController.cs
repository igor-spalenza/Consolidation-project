using CRM.Produto.Consolidacao.Dominio.Entidades;
using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CRM.Produto.Consolidacao.Apresentacao.Controllers
{
    public class PessoaController : Controller
    {
        private string FormataCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        private string FormataTelefone(string telefone)
        {
            return Convert.ToUInt64(telefone).ToString(@"\(00\)00000\-0000");
        }

        private string ReplaceCPF(string cpf)
        {
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            return cpf;
        }

        private string ReplaceCEP(string cep)
        {
            cep = cep.Replace("-", "");
            cep = cep.Replace(".", "");

            return cep;
        }

        private string ReplaceTelefone(string tel)
        {
            tel = tel.Replace("-", "");
            tel = tel.Replace("(", "");
            tel = tel.Replace(")", "");
            tel = tel.Replace(" ", "");

            return tel;
        }

        public ActionResult Index()
        {
            var pessoas = Dependencias.PessoaDAO.Obter();
            foreach (var pessoa in pessoas)
            {
                pessoa.CPF = FormataCPF(pessoa.CPF);
                pessoa.Telefone = FormataTelefone(pessoa.Telefone);
            }
            return View(pessoas);
        }

        [HttpPost]
        public ActionResult Inserir(Pessoa pessoa)
        {
            pessoa.Telefone = ReplaceTelefone(pessoa.Telefone);
            pessoa.CPF = ReplaceCPF(pessoa.CPF);
            pessoa.CEP = ReplaceCEP(pessoa.CEP);
            ModelState.Remove("Id");
            ModelState.Remove("DataCadastro");

            string messages = string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));

            if (ModelState.IsValid)
            {
                if (pessoa.Id == 0)
                {
                    try
                    {
                        Dependencias.PessoaDAO.Inserir(pessoa);
                    }
                    catch
                    {
                        return View("Cadastrar", pessoa);
                    }
                }
                else
                {
                    try
                    {
                        Dependencias.PessoaDAO.Editar(pessoa);
                    }
                    catch
                    {
                        return View("Cadastrar", pessoa);
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Cadastrar", pessoa);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var pessoa = Dependencias.PessoaDAO.Encontrar(id);
            return View("Cadastrar", pessoa);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public void Excluir(int id)
        {
            var pessoa = Dependencias.PessoaDAO.Encontrar(id);
            Dependencias.PessoaDAO.Remover(pessoa);
        }

        public ActionResult Detalhar(int id)
        {
            return View(Dependencias.PessoaDAO.Encontrar(id));
        }
    }
}