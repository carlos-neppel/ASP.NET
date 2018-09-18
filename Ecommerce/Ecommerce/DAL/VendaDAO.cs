using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class VendaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarVenda(Venda venda)
        {
            ctx.Vendas.Add(venda);
            ctx.SaveChanges();
        }
    }
}