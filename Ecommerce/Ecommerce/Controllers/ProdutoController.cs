using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        Context ctx = new Context();
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = ctx.Produtos.ToList();
            return View();
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao,
                                             string txtPreco, string txtCategoria)
        {
            Produto produto = new Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria
            };

            ctx.Produtos.Add(produto);
            ctx.SaveChages();

            return RedirectToAction("Index", "Produto");
        }


        public ActionResult RemoverProduto(int id)
        {
            Produto produto = ctx.Produtos.Find(id);
            ctx.Produtos.Remove(produto);
            ctx.SaveChages();
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult AlterarProduto(int id)
        {
            ViewBag.Produto = ctx.Produtos.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult AlterarProduto(string txtNome, string txtDescricao,
                                            string txtPreco, string txtCategoria, int txtId)
        {
            Produto produto = ctx.Produtos.Find(txtId);
            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = Convert.ToDouble(txtPreco);
            produto.Categoria = txtCategoria;

            ctx.Entry(produto).State = EmtityState.Modified;
            ctx.SaveChages();

            return RedirectToAction("Index", "Produto");
        }
    }


}

