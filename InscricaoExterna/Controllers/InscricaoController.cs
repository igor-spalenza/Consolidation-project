using InscricaoExterna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace InscricaoExterna.Controllers
{
    public class InscricaoController : Controller
    {
        // GET: Inscricao
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(InscricaoViewModel inscricaoViewModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58321/");
                //HTTP POST
                //client.GetAsync

                var postTask = client.PostAsJsonAsync("api/Inscricao", inscricaoViewModel);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return View("Confirmacao", "Inscricao");
                }
            }
            return View("Index", "Home");
        }
    }
}