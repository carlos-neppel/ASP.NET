using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        
        public int ProdutoId { get; set; }

        [Required(ErrorMessage ="Campo obrigatorio !")]
        [MaxLength(50, ErrorMessage ="O Campo deve ter no máximo de 50 caracteries")]
        [Display(Name = "nome do produto")]
        public String Nome {get; set; }

        [Display(Name = "descrição do produto")]
        [DataType (DataType.MultilineText)]
        public String  Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio !")]
        [Display(Name = "preço do produto")]
        public double Preco { get; set; }

        [Display(Name = "categoria do produto")]
        public String  Categoria { get; set; }


        public String Imagem { get; set; }
         

              
    }
}