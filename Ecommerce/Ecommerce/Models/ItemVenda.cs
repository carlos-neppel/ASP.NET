using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }

        public Produto Produto { get; set; }

        public  int Quantidade { get; set; }

        public Double Preco { get; set; }

        public DateTime Data { get; set;  }
    }
}