using Microsoft.AspNetCore.Mvc;
using SistemaDeContatos.Models;
using SistemaDeContatos.Repositório;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View();
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar o contato";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = "Não conseguimos registrar o contato, tente novamente, detalhe do erro: " + erro.Message;
                throw;
            }
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato registrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = "Não conseguimos registrar o contato, tente novamente, detalhe do erro: " + erro.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = "Não conseguimos registrar o contato, tente novamente, detalhe do erro: " + erro.Message;
                return RedirectToAction("Index");
            }
        }
    }
}