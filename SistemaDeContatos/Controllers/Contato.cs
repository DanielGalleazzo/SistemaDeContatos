using Microsoft.AspNetCore.Mvc;
using SistemaDeContatos.Models;
using SistemaDeContatos.Repositório;

namespace SistemaDeContatos.Controllers
{
    public class Contato : Controller
    {

        private readonly InterfaceContatoRepositorio _contatoRepositorio;
        public Contato(InterfaceContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult Apagar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
