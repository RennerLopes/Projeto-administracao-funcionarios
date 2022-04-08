using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixConsult.Funcionarios.Classes
{
    public class Funcionario : EntidadeBase
    {
        private string nome { get; set; }
        private string sobrenome { get; set; }
        private string email { get; set; }
        private string numeroChapa { get; set; }
        public List<Telefone> telefones { get; set; }
        private string senha { get; set; }

        public Funcionario(int Id, string nome, string sobrenome, string email, string numeroChampa, List<Telefone> telefones, string senha)
        {
            this.Id = Id;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.email = email;
            this.numeroChapa = numeroChampa;
            this.telefones = telefones;
            this.senha = senha;
        }

        // static bool validaEmail(string email)
        // {
        //     if (email == null)
        //     {
        //         return false;
        //     }

        //     if (new EmailAddressAttribute().IsValid(email))
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }

        public int retornaId()
        {
            return this.Id;
        }

        public string retornaNome()
        {
            return this.nome;
        }

        public string retornaSobrenome()
        {
            return this.sobrenome;
        }

        public string retornaEmail()
        {
            return this.email;
        }

        public string retornaNumeroChapa()
        {
            return this.numeroChapa;
        }

        public string retornaSenha()
        {
            return this.senha;
        }

        public List<Telefone> retornaTelefones()
        {
            return this.telefones;
        }

    }
}