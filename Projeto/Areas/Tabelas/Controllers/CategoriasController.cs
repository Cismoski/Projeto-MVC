using System.Web.Mvc;
using Modelo.Tabelas;
using System.Net;
using Servico.Tabelas;

namespace Projeto.Areas.Tabelas.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaServico categoriaServico = new CategoriaServico();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }

        // GET: Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }
        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        private void PopularViewBag(Categoria categoria = null)
        {
            if (categoria == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome", categoria.CategoriaId);
            }
        }

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            PopularViewBag(categoriaServico.ObterCategoriaPorId((long)id));
            return ObterVisaoCategoriaPorId(id);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId((long)id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId((long)id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {

            return GravarCategoria(categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria = categoriaServico.RemoverCategoria(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removida.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}