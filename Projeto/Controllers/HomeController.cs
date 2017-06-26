using Modelo.Cadastros;
using Servico.Cadastros;
using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {

        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        // GET: Home
        public ActionResult Index()
        {
            PopularViewBag();
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }


        private void PopularViewBag()
        {
            ViewBag.CategoriaId = categoriaServico.ObterCategoriasClassificadasPorNome().ToList<Modelo.Tabelas.Categoria>();
        }
    }
}