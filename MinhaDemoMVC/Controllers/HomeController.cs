using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KissLog;
using Microsoft.AspNetCore.Mvc;
using MinhaDemoMVC.Models;

namespace MinhaDemoMVC.Controllers
{
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {
        private readonly ILogger  _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        //[Route("")]
        //[Route("pagina-inicial")]
        //[Route("pagina-inicial/{id:int}/{categorias:guid?}")]
       // public IActionResult Index(int id, Guid categorias)
        public IActionResult Index()
        {
            var filme = new Filme
            {
                Titulo = "Oi",
                DataLancamento = DateTime.Now,
                Genero = null,
                Avaliacao = 10,
                Valor = 20000
            };

            _logger.Trace("Usuário acessou a Home");   
            
            //return RedirectToAction("Privacy", filme);
            return View();
        }

        [Route("privacidade")]
        [Route("politica-privacidade")]
        public IActionResult Privacy(Filme filme)
        {

            if (ModelState.IsValid)
            {
             
            }

            foreach (var error in ModelState.Values.SelectMany(m=>m.Errors))
            {
                Console.WriteLine(error.ErrorMessage);

            }

            try
            {
                throw new Exception("Algo ocorreu!!!");    
            }
            catch (Exception e)
            {

                _logger.Error(e);
                throw;
            }
           
            return View();
            //return Json(new
            //{
            //    Nome = "Linha de Codigo",
            //    URL = "www.linhadecodigo.com.br"
            //});

            //var fileBytes = System.IO.File.ReadAllBytes(@"C:\Labs\desenvolvedor-io-asp.net-core-expert\README.md");
            //var fileName = "joao.md";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            //return Content("<h1>Joao<h1>");

        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //[Route("erro-encontrado")]
        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {

            var modelError = new ErrorViewModel();

            if(id == 500)
            {
                modelError.Mensagem = "Ocorreu um erro! Erro 5xx";
                modelError.Titulo = "Ops, página não encontrada";
                modelError.ErroCode = id;
            }else if (id == 404)
            {
                modelError.Mensagem = "Ocorreu um erro! Erro 404";
                modelError.Titulo = "Ops, página não encontrada";
                modelError.ErroCode = id;
            }
            else if (id == 403)
            {
                modelError.Mensagem = "Ocorreu um erro! Erro 403";
                modelError.Titulo = "Ops, página não encontrada";
                modelError.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }
            return View("Error",modelError);
        }
    }
}
