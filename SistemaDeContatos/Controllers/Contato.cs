using Microsoft.AspNetCore.Mvc;

namespace SistemaDeContatos.Controllers
{
    public class Contato : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
