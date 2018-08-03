using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
        Context ctx = new Context();

        public static List<Produto> RetornarProduto()
        {
            return ctx.Produtos.ToList();
        }

        public static void RemoverProduto(id)
        {
           
            ctx.Produtos.Remove(BuscarProdutoPorId(id));
            ctx.SaveChages();
        }

        internal static Produto BuscarProdutoPorId(int txtId)
        {
            throw new NotImplementedException();
        }

        public static void AlterarProduto(Produto produto)
        {
            ctx.Entry(produto).State = EmtityState.Modified;
            ctx.SaveChages();
        }
    }
}