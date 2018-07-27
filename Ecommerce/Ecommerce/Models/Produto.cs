using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    [Table("Produto")]
    public class Produto
    {
        [key]
        public int ProdutoId { get; set; }
        public String Nome {get; set; }
        public String  Descricao { get; set; }
        public double Preco { get; set; }
        public String  Categoria { get; set; }
        public String Imagem { get; set; }
         

              
    }
}