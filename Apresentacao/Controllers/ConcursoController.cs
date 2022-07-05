using CRM.Produto.Consolidacao.Apresentacao.Models;
using CRM.Produto.Consolidacao.Dominio.Entidades;
using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using System;
using System.Net;
using System.Web.Mvc;

namespace CRM.Produto.Consolidacao.Apresentacao.Controllers
{
    public class ConcursoController : Controller
    {
        // GET: Concurso
        public ActionResult Index()
        {
            return View(Dependencias.ConcursoDAO.Obter());
        }

       [HttpPost]
        public ActionResult Inserir(Concurso concurso)
        {
            ModelState.Remove("Id"); 
            ModelState.Remove("DataCadastro"); 
            if (ModelState.IsValid)
            {
                if (concurso.Id == 0)
                {

                    try
                    {
                        concurso.DataCadastro = DateTime.Now;
                        Dependencias.ConcursoDAO.Inserir(concurso);
                    }
                    catch
                    {
                        return View("Cadastrar", concurso);
                    }
                } 
                else
                {
                    try
                    {
                        Dependencias.ConcursoDAO.Editar(concurso);
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var concurso = Dependencias.ConcursoDAO.Encontrar(id);
            return View("Cadastrar", concurso);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Excluir(int id)
        {
            var concurso = Dependencias.ConcursoDAO.Encontrar(id);
            
            if (concurso.Situacao)
            {
                return Json(new Resultado(false, "O Concurso não pôde ser excluído porque está publicado"), JsonRequestBehavior.AllowGet);
            }
            else if (Dependencias.ConcursoDAO.PossuiCurso(concurso.Id))
            {
                return Json(new Resultado(false, "O Concurso não pôde ser excluído pois contém Cursos vinculados. É necessário primeiramente excluir os Cursos relacionados!"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    Dependencias.ConcursoDAO.Remover(concurso.Id);
                }
                catch (Exception e)
                {
                    return Json(new Resultado(false, e.Message), JsonRequestBehavior.AllowGet);
                }

                return Json(new Resultado(true, "Exclusão realizada com sucesso!"), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detalhar(int id)
        {
            Concurso model = Dependencias.ConcursoDAO.Encontrar(id);
            return View(model);
        }
    }
}