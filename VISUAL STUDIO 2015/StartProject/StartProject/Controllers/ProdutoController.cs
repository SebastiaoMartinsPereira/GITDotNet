using StartProject.DAO;
using StartProject.Filtros;
using StartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartProject.Controllers
{
    [AutorizacaoFilterAtributte]
    public class ProdutoController : Controller
    {
        private ProdutosDAO dao;
        private CategoriasDAO daoCtg;

        public ProdutoController(ProdutosDAO dao,CategoriasDAO daoCtg)
        {
            this.dao = dao;
            this.daoCtg = daoCtg;
        }

        // GET: Produto
        [Route("produtos",Name ="ListaProdutos")]
        public ActionResult Index()
       {
            //instancia o Gerenciador Sql de produto
            //ProdutosDAO produtoDAO = new ProdutosDAO();
            //recupera a lista de produtosnabase de dados atráves do ORM(Entity FrameWork)
            IList<Produto> ListProdutos = this.dao.Lista();

           var list =  from l in ListProdutos
                        where (l.Id > 0 && l.Nome != null)
                        select l;
           
            //transfere a lista de produtos para a Bag para que possa ser usado na camada de visão

            //estou mandando o produto agora no paraametro principal do metodo View;
            //ViewBag.Produtos = ListProdutos;
            //chama a camada de visão.
            return View(list.ToList<Produto>());
        }

        public ActionResult Form()
        {
            ViewBag.Categorias = dao.Lista();
            ViewBag.Produto = new Produto();
            return View();
        }

        [ValidateAntiForgeryToken,HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            if (produto.CategoriaID.Equals(1) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.PrecoInvalido", "Produtos da categoria informática devem ter o Valor superior a 100 R$!.");
            }

            if (ModelState.IsValid)
            {
                //var dao = new ProdutosDAO();
                this.dao.Adiciona(produto);
                return RedirectToAction("Index", "Home");
            }
            else
            {
               
                ViewBag.Categorias = dao.Lista();
                ViewBag.Produto = produto;
                return View("Form");
            }
        }


        /// <summary>
        /// Recebe como parametro o Id do produto a ser carregado
        /// o parametro e enviado a partir do Index.cshtml pelo atributo Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("produtos/{id}",Name ="VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            ViewBag.Produto = this.dao.BuscaPorId(id);
            ViewBag.Categorias = dao.Lista();
            return View();
        }

        public ActionResult DecrementaQtd(int id)
        {
            
            var produto = this.dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);
            return Json(produto);
            
        }

        public ActionResult ProdutoComPrecoMinimo(double? preco)
        {
            IEnumerable<Produto> produtos = dao.ProdutoComPrecoMaiorQue(preco);
            return View(produtos);
        }

        //[Route("produtos/remove/{id}", Name = "RemoveProduto")]
        public ActionResult Remove(int id)
        {
            var produto = this.dao.BuscaPorId(id);
            if (produto != null)
            {
                dao.Remove(produto);
            }

            return RedirectToRoute("ListaProdutos", "produtos");
        }

        public ActionResult ProdutosDaCategoria(string nomeCategoria)
        {
            IEnumerable<Produto> produtos = dao.ProdutosDaCategoria(nomeCategoria);
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoriaComPrecoMinimo(string nomeCategoria,double preco)
        {
            IEnumerable<Produto> produtos = dao.ProdutosDaCategoriaComPrecoMaiorDoQue(nomeCategoria,preco);
            return View(produtos);
        }
    }
}