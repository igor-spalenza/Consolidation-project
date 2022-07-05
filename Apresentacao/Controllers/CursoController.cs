using CRM.Produto.Consolidacao.Apresentacao.Models;
using CRM.Produto.Consolidacao.Dominio.Entidades;
using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Produto.Consolidacao.Apresentacao.Controllers
{
    public class CursoController : Controller
    {

        public ActionResult Index()
        {

            return View(Dependencias.CursoDAO.Obter());
        }

        [HttpPost]
        public ActionResult Inserir(Curso curso)
        {
            ModelState.Remove("Id");
            ModelState.Remove("DataCadastro");
            ModelState.Remove("ConcursoId");
            if (ModelState.IsValid)
            {
                if (curso.Id == 0)
                {
                    try
                    {
                        curso.DataCadastro = DateTime.Now;
                        Dependencias.CursoDAO.Inserir(curso);
                    }
                    catch
                    {
                        var concursos = Dependencias.CursoDAO.ConcursosAtivos();
                        ViewBag.Concursos = concursos;
                        return View("Cadastrar", curso);
                    }
                }
                else
                {
                    try
                    {
                        Dependencias.CursoDAO.Editar(curso);
                    }
                    catch
                    {
                        var concursos = Dependencias.CursoDAO.ConcursosAtivos();
                        ViewBag.Concursos = concursos;
                        return View("Cadastrar", curso);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var concursos = Dependencias.CursoDAO.ConcursosAtivos();
            ViewBag.Concursos = concursos;
            var curso = Dependencias.CursoDAO.Encontrar(id);
            return View("Cadastrar", curso);
        }

        public ActionResult Cadastrar()
        {
            //Curso cursos = new Curso();
            var concursos = Dependencias.CursoDAO.ConcursosAtivos();
            ViewBag.Concursos = concursos;
            return View(new Curso());
        }

        [HttpGet]
        public JsonResult Excluir(int id)
        {
            
            var curso = Dependencias.CursoDAO.Encontrar(id);
            if (Dependencias.CursoDAO.VerificaConcursoPublicado(curso.ConcursoId))
            {
                return Json(new Resultado(false,"A Oferta de Curso não pode ser excluída pois seu Concurso está publicado"), JsonRequestBehavior.AllowGet);
            } 
            else if (Dependencias.CursoDAO.PossuiInscricao(curso.Id))
            {
                return Json(new Resultado(false, "A Oferta de Curso não pode ser excluída pois contém Inscrições ativas"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    Dependencias.CursoDAO.Remover(curso.Id);
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
            return View(Dependencias.CursoDAO.Encontrar(id));
        }
    }
}
