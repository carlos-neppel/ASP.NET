using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class ItemVendaDAO
    {

        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarItemVenda(ItemVenda itemVenda)
        {
            ctx.ItemVenda.Add(itemVenda);
            ctx.SaveChanges();

        }
        public static List<ItemVenda> RetornarItensVenda()
        {
            return ctx.ItemVenda.ToList();
        }
    }
}