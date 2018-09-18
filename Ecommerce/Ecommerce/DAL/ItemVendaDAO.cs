using Ecommerce.Models;
using Ecommerce.Utils;
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
            string carrinhoId = Sessao.RetonarCarrinhoId();

            ItemVenda item = ctx.ItensVenda.
                Include("Produto").FirstOrDefault(
                x => x.Produto.ProdutoId == itemVenda.Produto.ProdutoId &&
                x.CarrinhoId.Equals(carrinhoId));

            if (item == null)
            {
                ctx.ItensVenda.Add(itemVenda);
            }
            else
            {
                item.Quantidade++;
            }
            ctx.SaveChanges();
        }

        public static List<ItemVenda> BuscarItensVendaPorCarrinhoId()
        {
            string carrinhoId = Sessao.RetonarCarrinhoId();
            return ctx.ItensVenda.
                Include("Produto").
                Where(x => x.CarrinhoId.Equals(carrinhoId)).ToList();
        }

        public static void RemoverItem(int id)
        {
            ItemVenda item = ctx.ItensVenda.Find(id);

            if (item.Quantidade > 1)
            {
                item.Quantidade--;
            }
            else
            {
                ctx.ItensVenda.Remove(item);
            }
            ctx.SaveChanges();
        }
        public static void AdicionarItem(int id)
        {
            ItemVenda item = ctx.ItensVenda.Find(id);
            item.Quantidade++;
            ctx.SaveChanges();
        }
        public static void DiminuirItem(int id)
        {
            ItemVenda item = ctx.ItensVenda.Find(id);
            if (item.Quantidade > 1)
            {
                item.Quantidade--;
                ctx.SaveChanges();
            }
        }

        public static double RetornarTotalCarrinho()
        {
            return BuscarItensVendaPorCarrinhoId().Sum(x => x.Quantidade * x.Preco);
        }
        public static double RetornarQuantidadeItensCarrinho()
        {
            return BuscarItensVendaPorCarrinhoId().Sum(x => x.Quantidade);
        }
    }
}