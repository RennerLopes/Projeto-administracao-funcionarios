using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SixConsult.Funcionarios.Classes;

namespace SixConsult.Funcionarios.Web
{
    [Index(nameof(numeroChapa), IsUnique = true)]
    public class FuncionarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "nome is required.")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Sobrenome is required.")]
        public string sobrenome { get; set; }
        [Required(ErrorMessage = "Email não é válido da instituição."), RegularExpression("^(.+)@gmail(.+)$", ErrorMessage = "Email não é válido da instituição.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Chapa is required.")]
        public string numeroChapa { get; set; }
        public List<Telefone> telefones { get; set; }
        [Required(ErrorMessage = "Senha is required.")]
        public string senha { get; set; }

        public FuncionarioModel() { }

        public FuncionarioModel(Funcionario funcionario)
        {
            Id = funcionario.retornaId();
            nome = funcionario.retornaNome();
            sobrenome = funcionario.retornaSobrenome();
            email = funcionario.retornaEmail();
            numeroChapa = funcionario.retornaNumeroChapa();
            telefones = funcionario.retornaTelefones();
            senha = funcionario.retornaSenha();
        }

        public Funcionario ToFuncionario()
        {
            return new Funcionario(Id, nome, sobrenome, email, numeroChapa, telefones, senha);
        }
    }
}