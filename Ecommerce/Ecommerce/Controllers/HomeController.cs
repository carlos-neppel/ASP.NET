using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
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
    }
}