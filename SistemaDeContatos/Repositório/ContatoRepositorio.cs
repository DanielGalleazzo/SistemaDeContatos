using SistemaDeContatos.Data;
using SistemaDeContatos.Models;

namespace SistemaDeContatos.Repositório
{
    public class ContatoRepositorio : InterfaceContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext) {
        
            _bancoContext = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
    }
}
