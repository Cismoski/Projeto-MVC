using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using Servico.Cadastros;

namespace Projeto.Controllers
{
    public class VendedoresController : Controller
    {

        private VendedorServico vendedorServico = new VendedorServico();
        // GET: Vendedores
        public ActionResult Index()
        {
            return View(vendedorServico.ObterVendedoresClassificadosPorNome());
        }

        public ActionResult Create()
        {
            return View();
        }

        private ActionResult ObterVisaoVendedorPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = vendedorServico.ObterVendedorPorId((long)id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        private ActionResult GravarVendedor(Vendedor vendedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vendedorServico.GravarVendedor(vendedor);
                    return RedirectToAction("Index");
                }
                return View(vendedor);
            }
            catch
            {
                return View(vendedor);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendedor vendedor)
        {
            return GravarVendedor(vendedor);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoVendedorPorId((long)id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Vendedor vendedor = vendedorServico.RemoverVendedor(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoVendedorPorId((long)id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendedor vendedor)
        {
            return GravarVendedor(vendedor);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoVendedorPorId((long)id);
        }

    }
}