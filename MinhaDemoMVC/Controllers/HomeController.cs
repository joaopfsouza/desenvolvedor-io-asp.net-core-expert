using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaDemoMVC.Models;

namespace MinhaDemoMVC.Controllers
{
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("pagina-inicial")]
        [Route("pagina-inicial/{id:int}/{categorias:guid?}")]
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

            return RedirectToAction("Privacy", filme);
           // return View();
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
            // return View();
            //return Json(new
            //{
            //    Nome = "Linha de Codigo",
            //    URL = "www.linhadecodigo.com.br"
            //});

            //var fileBytes = System.IO.File.ReadAllBytes(@"C:\Labs\desenvolvedor-io-asp.net-core-expert\README.md");
            //var fileName = "joao.md";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            return Content("<h1>Joao<h1>");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
