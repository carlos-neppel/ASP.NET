using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail do usuário")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Senha do usuário")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        [Display(Name = "Confirmação da senha")]
        [NotMapped]
        public string ConfirmacaoSenha { get; set; }

        [Display(Name = "CEP do usuário")]
        public string Cep { get; set; }

        [Display(Name = "Endereço do usuário")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro do usuário")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade do usuário")]
        public string Localidade { get; set; }

        [Display(Name = "Estado do usuário")]
        public string Uf { get; set; }


    }
}