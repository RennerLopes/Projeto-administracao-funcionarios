using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixConsult.Funcionarios.Classes
{
    public class Telefone : EntidadeBase
    {
        [Required(ErrorMessage = "ddd é obrigatorio.")]
        public string ddd { get; set; }
        [Required(ErrorMessage = "numero é obrigatorio.")]
        public string numero { get; set; }
        public TipoTelefone tipoTelefone { get; set; }
        public Telefone(string ddd, string numero)
        {
            if (this.numero != null || this.ddd != null)
            {
                validaNumeroTelefone(numero, tipoTelefone);
                validaDDD(ddd);
            }

            this.tipoTelefone = tipoTelefone;
            this.numero = numero;
            this.ddd = ddd;
        }

        private void validaDDD(String ddd)
        {
            if (ddd.Length != 2)
            {
                throw new ArgumentException("DDD tem que ter dois dígitos");
            }
        }

        private void validaNumeroTelefone(String numero, TipoTelefone tipoTelefone)
        {
            if (tipoTelefone.Equals(TipoTelefone.Celular))
            {
                if (numero.Length != 9)
                {
                    throw new ArgumentException("Celular tem que ter 9 dígitos em seu número");
                }
            }
            else
            {
                if (numero.Length != 8)
                {
                    throw new ArgumentException("Telefone Fixo tem que ter 8 dígitos em seu número");
                }
            }
        }

        public string retornaDdd()
        {
            return ddd;
        }

        public string retornaNumero()
        {
            return numero;
        }

        public string toString()
        {
            return "(" + this.ddd + ") " + this.numero;
        }
    }
}