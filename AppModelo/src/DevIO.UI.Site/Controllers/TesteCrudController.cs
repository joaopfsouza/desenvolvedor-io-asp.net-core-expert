using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.UI.Site.Data;
using DevIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {

        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext context)
        {
            _contexto = context;
        }


        public IActionResult Index()
        {
            var aluno = new Aluno {
                Nome="Joao",
                DataNascimento=DateTime.Now,
                Email = "joao@jax.com"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(a=>a.Email == "joao@jax.com");
            var aluno4 = _contexto.Alunos.Where(a=>a.Nome == "Joao");

            aluno.Nome = "Paulo";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();


            return View();
        }
    }
}