﻿using SistemaDeContatos.Controllers;
using SistemaDeContatos.Data;
using SistemaDeContatos.Models;

namespace SistemaDeContatos.Repositório
{
    public class ContatoRepositorio : InterfaceContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext) {

            this._bancoContext = bancoContext;
        }
        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);
            if (contatoDB == null) 
            throw new SystemException("Houve uma atualização no contato");
            contatoDB.Name = contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.Celular= contato.Celular;
            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        public bool Apagar(int id)
        {
           
            ContatoModel contatoDB = ListarPorId(id);
            if (contatoDB == null)
            throw new SystemException("Houve um erro ao apagar o contato");
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}