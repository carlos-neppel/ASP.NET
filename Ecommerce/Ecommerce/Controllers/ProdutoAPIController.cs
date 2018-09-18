using Ecommerce.DAL;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ecommerce.Controllers
{
    [RoutePrefix("api/Produto")]
    public class ProdutoAPIController : ApiController
    {
        [Route("Produtos")]
        public List<Produto> GetProdutos()
        {
            return ProdutoDAO.RetornarProdutos();
        }

        //GET: api/Produto/ProdutoPorCategoria
        [Route("ProdutosPorCategoria/{categoriaId}")]
        public List<Produto> GetProdutosPorCategoria(int categoriaId)
        {
            return ProdutoDAO.BuscarProdutosPorCategoria(categoriaId);
        }


        //GET: api/Produto/ProdutoPorId/5

        [Route("ProdutoPorId/{ProditoId}")]
        public dynamic GetProdutoPorId(int produtoId)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(produtoId);
            if(produto != null)
            {
                dynamic produtoDinamico = new
                {
                    nome = produto.Nome,
                    Preco = produto.Preco.ToString("C2"),
                    categoria = produto.Categoria,
                    dataEnvio = DateTime.Now 

                };
                return produtoDinamico;
            }
            return NotFound();
        }
    }
}
