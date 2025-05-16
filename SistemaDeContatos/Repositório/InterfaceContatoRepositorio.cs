using SistemaDeContatos.Models;

namespace SistemaDeContatos.Repositório
{
    public interface InterfaceContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
