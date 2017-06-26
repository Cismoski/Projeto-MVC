using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using Servico.Cadastros;
using Servico.Tabelas;
using System.Web;
using System.IO;
using System;
using System.Collections.Generic;

namespace Projeto.Areas.Cadastros.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }


        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoServico.ObterProdutoPorId((long) id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        private void PopularViewBag(Produto produto = null)
        {
            if(produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome",produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome",produto.FabricanteId);
            }
        }

        private ActionResult GravarProduto(Produto produto, HttpPostedFileBase logotipo, string chkRemoverImagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(chkRemoverImagem != null)
                    {
                        produto.Logotipo = null;
                    }
                    if(logotipo != null)
                    {
                        produto.LogotipoMimeType = logotipo.ContentType;
                        produto.Logotipo = SetLogotipo(logotipo);
                        produto.NomeArquivo = logotipo.FileName;
                        produto.TamanhoArquivo = Convert.ToInt32(logotipo.ContentLength);
                    }
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                PopularViewBag(produto);
                return View(produto);
            }
            catch
            {
                PopularViewBag(produto);
                return View(produto);
            }
        }

        private byte[] SetLogotipo(HttpPostedFileBase logotipo)
        {
            var bytesLogotipo = new byte[logotipo.ContentLength];
            logotipo.InputStream.Read(bytesLogotipo, 0, logotipo.ContentLength);
            return bytesLogotipo;
        }
        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {

            PopularViewBag();
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            return GravarProduto(produto,null,null);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(produtoServico.ObterProdutoPorId((long) id));
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(long? id,HttpPostedFileBase logotipo = null, string chkRemoverImagem = null)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoServico.ObterProdutoPorId((long)id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return GravarProduto(produto, logotipo, chkRemoverImagem);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Produto produto = produtoServico.RemoverProduto(id);
                TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi removido.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public FileContentResult GetLogotipo (long id)
        {
            Produto produto = produtoServico.ObterProdutoPorId(id);
            if(produto != null)
            {
                return File(produto.Logotipo, produto.LogotipoMimeType);
            }
            return null;
        }

        public ActionResult DownloadArquivo(long id)
        {
            Produto produto = produtoServico.ObterProdutoPorId(id);
            FileStream fileStream = new FileStream(Server.MapPath("~/TempData/" + produto.NomeArquivo), FileMode.Create, FileAccess.Write);
            fileStream.Write(produto.Logotipo, 0, Convert.ToInt32(produto.TamanhoArquivo));
            fileStream.Close();
            return File(fileStream.Name,produto.LogotipoMimeType,produto.NomeArquivo);
        }

        public JsonResult GetProdutosPorNome(string param)
        {
            var r = produtoServico.ObterProdutosPorNome(param);
            return Json(r, JsonRequestBehavior.AllowGet);
        }

    }
}
