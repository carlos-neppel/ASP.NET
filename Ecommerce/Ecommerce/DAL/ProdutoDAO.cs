using Ecommerce.Controllers;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
       private static Context ctx = new Context();
        private static object EntityState;

        public static List<Produto> RetornarProduto()
        {
            return ctx.Produtos.ToList();
        }

        public static void CadastrarProduto(Produto produto)
        {
            ctx.Produtos.Add(produto);
            ctx.SaveChages();
        }

        public static void RemoverProduto(int id)
        {
            ctx.Produtos.Remove (BuscarProdutoPorId(id));
            ctx.SaveChages();

        } 

        public static Produto BuscarProdutoPorId(int id)
        {
            return ctx.Produtos.Find(id);
        }

        public static void AlterarProduto(Produto produto)
        {
            ctx.Entry(produto).State = EntityState.Modified;
            ctx.SaveChages();
        }

        
    }
}