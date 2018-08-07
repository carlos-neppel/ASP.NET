using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
        private static Context ctx = new Context();

        public static List<Produto> RetornarProdutos()
        {
            return ctx.Produtos.ToList();

        }


        public static bool CadastrarProduto(Produto produto)
        {
            if(BuscarProdutoPorNome(produto) == null)
            {
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();

                return true;
            }
            return false;
           
        }

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return ctx.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }

        public static void RemoverProduto(int id)
        {
            ctx.Produtos.Remove(BuscarProdutoPorId(id));
            ctx.SaveChanges();

        }

        public static Produto BuscarProdutoPorId(int id)
        {
            return ctx.Produtos.Find(id);
        }

        public static void AlterarProduto(Produto produto)
        {
            ctx.Entry(produto).State = EntityState.Modified;
            ctx.SaveChanges();
        }


    }
}