using Ecommerce.DAL;
using Ecommerce.Models;
using Ecommerce.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.Categorias = CategoriaDAO.RetornarCategorias();
            if (id == null)
            {
                return View(ProdutoDAO.RetornarProdutos());
            }
            return View(ProdutoDAO.BuscarProdutosPorCategoria(id));
        }

        public ActionResult DetalheProduto(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        public ActionResult AdicionarAoCarrinho(int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            ItemVenda itemVenda = new ItemVenda
            {
                Produto = produto,
                Quantidade = 1,
                Preco = produto.Preco,
                Data = DateTime.Now,
                CarrinhoId = Sessao.RetonarCarrinhoId()
            };
            ItemVendaDAO.CadastrarItemVenda(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult CarrinhoCompras()
        {
            ViewBag.Total = ItemVendaDAO.RetornarTotalCarrinho();
            return View(ItemVendaDAO.
                BuscarItensVendaPorCarrinhoId());
        }

        public ActionResult RemoverItem(int id)
        {
            ItemVendaDAO.RemoverItem(id);
            return RedirectToAction("CarrinhoCompras", "Home");
        }

        public ActionResult AdicionarItem(int id)
        {
            ItemVendaDAO.AdicionarItem(id);
            return RedirectToAction("CarrinhoCompras", "Home");
        }

        public ActionResult DiminuirItem(int id)
        {
            ItemVendaDAO.DiminuirItem(id);
            return RedirectToAction("CarrinhoCompras", "Home");
        }

        public ActionResult FinalizarCompra()
        {
            ViewBag.Itens = ItemVendaDAO.BuscarItensVendaPorCarrinhoId();
            return View();
        }

        [HttpPost]
        public ActionResult FinalizarCompra(Venda venda)
        {
            venda.CarrinhoId = Sessao.RetonarCarrinhoId();
            venda.ItensVenda = ItemVendaDAO.BuscarItensVendaPorCarrinhoId();
            Sessao.ZerarSessaoCarrinho();
            VendaDAO.CadastrarVenda(venda);
            return RedirectToAction("Index", "Home");
        }
    }
}