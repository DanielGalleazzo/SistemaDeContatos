using SistemaDeContatos.Models;

namespace SistemaDeContatos.Repositório
{
    public interface InterfaceContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
