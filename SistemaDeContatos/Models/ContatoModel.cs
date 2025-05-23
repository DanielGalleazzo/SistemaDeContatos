﻿using System.ComponentModel.DataAnnotations;

namespace SistemaDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do contato é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O e-mail do contato é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O celular do contato é obrigatório")]
        [Phone(ErrorMessage = "O celular informado é inválido")]
        public string Celular { get; set; }
    }
}
