using StartProject.DAO;
using StartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartProject.Controllers
{
    public class VendasController : Controller
    {
        private VendasDAO vendasDAO;
        private UsuariosDAO usuariosDAO;

        private ProdutosDAO produtosDAO;

        public object Carrinho { get; private set; }

        public VendasController(VendasDAO vendasDAO,
            ProdutosDAO produtosDAO, UsuariosDAO usuariosDAO)
        {
            this.vendasDAO = vendasDAO;
            this.produtosDAO = produtosDAO;
            this.usuariosDAO = usuariosDAO;
        }

        public ActionResult ListaProdutos()
        {
            IEnumerable<Produto> produtos = produtosDAO.Lista();
            ViewBag.ProdutosNoCarrinho = Carrinho.Produtos.Count;
            return View(produtos);
        }

        public ActionResult FechaPedido()
        {
            IEnumerable<Produto> produtos = this.Carrinho.Produtos;
            IEnumerable<Usuario> usuarios = this.usuariosDAO.Lista();
            ViewBag.Usuarios = usuarios;
            return View(produtos);
        }

        public ActionResult AdicionaProduto(int produtoId)
        {
            Produto produto = produtosDAO.BuscaPorId(produtoId);
            Carrinho.Adiciona(produto);
            return RedirectToAction("ListaProdutos");
        }


        public ActionResult CompletaPedido(Usuario usuario)
        {
            Venda venda = this.Carrinho.CriaVenda(usuario);
            vendasDAO.Adiciona(venda);
            this.Carrinho = new Carrinho();
            return RedirectToAction("Index"); 
        }

    }
}