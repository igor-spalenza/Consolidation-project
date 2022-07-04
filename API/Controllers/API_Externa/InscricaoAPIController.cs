using API.Models;
using CRM.Produto.Consolidacao.Dominio.Entidades;
using CRM.Produto.Consolidacao.Dominio.InjecaoDependencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers.API_Externa
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InscricaoAPIController : ApiController
    {

        // GET: InscricaoAPI
        [HttpGet, Route("api/Inscricao/")]
        public Inscricao PegasInscricao()
        {
            return new Inscricao();
        }

        [HttpPost, Route("api/Inscricao/")]
        public IHttpActionResult Inscrever([FromBody] InscricaoViewModel inscricao)
        {
            Inscricao objetoInscricao = null;

            try
            {
                if (inscricao.PessoaId == 0)
                {
                    Pessoa objetoPessoa = new Pessoa(
                        inscricao.Nome, 
                        inscricao.CPF, 
                        inscricao.RG, 
                        inscricao.Email, 
                        inscricao.Telefone, 
                        inscricao.DataNascimento, 
                        inscricao.CEP, 
                        inscricao.Logradouro, 
                        inscricao.Numero, 
                        inscricao.Complemento, 
                        inscricao.Bairro, 
                        inscricao.Cidade, 
                        inscricao.Estado);
                    
                    Dependencias.PessoaDAO.Inserir(objetoPessoa);

                    objetoInscricao = new Inscricao(
                        objetoPessoa.Id,
                        inscricao.CursoId,
                        inscricao.Modalidade);
                }
                else
                {
                    objetoInscricao = new Inscricao(
                        inscricao.PessoaId,
                        inscricao.CursoId,
                        inscricao.Modalidade);
                }
                Dependencias.InscricaoDAO.Inserir(objetoInscricao);
                return StatusCode(System.Net.HttpStatusCode.Created);

            }
            catch (Exception e)
            {
                throw e;
                //return StatusCode(System.Net.HttpStatusCode.BadRequest);
            }

        }

        [HttpGet, Route("api/Pessoa/")]
        public Pessoa BuscarCPF(string cpf)
        {
            
            return Dependencias.PessoaDAO.BuscarCPF(cpf);
            //StatusCode(System.Net.HttpStatusCode.Created);
        }

        [HttpGet, Route("api/Concurso/")]
        public List<Concurso> BuscarConcursos()
        {
            return Dependencias.ConcursoDAO.BuscarConcursosPublicados();
        }

        [HttpGet, Route("api/Curso/{id}")]
        public List<Curso> CursosDisponiveis(int id)
        {
            return Dependencias.ConcursoDAO.CursosDesteConcurso(id);
        }

        //[HttpPut, Route("api/inscricao/")]
        //public IHttpActionResult Inscrever([FromBody] Inscricao inscricao)
        //{
        //    Dependencias.InscricaoDAO.Inserir(inscricao);
        //    return StatusCode(System.Net.HttpStatusCode.Created);
        //}

        //[HttpDelete, Route("api/inscricao/")]
        //public IHttpActionResult Inscrever([FromBody] Inscricao inscricao)
        //{
        //    Dependencias.InscricaoDAO.Inserir(inscricao);
        //    return StatusCode(System.Net.HttpStatusCode.Created);
        //}
    }
}