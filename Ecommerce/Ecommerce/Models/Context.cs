using System;

namespace Ecommerce.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbEcommerce") { }

        //Mapear as classes que vão virar tabela no banco
        public DbSet<Produto> Produtos { get; set; }

        internal void SaveChages()
        {
            throw new NotImplementedException();
        }
    }
}