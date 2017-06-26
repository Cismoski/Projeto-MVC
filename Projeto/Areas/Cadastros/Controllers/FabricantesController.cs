using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using Servico.Cadastros;
using Servico.Tabelas;

namespace Projeto.Areas.Cadastros.Controllers
{
    public class FabricantesController : Controller
    {
        private FabricanteServico fabricanteServico = new FabricanteServico();
        private EstadoServico estadosServico = new EstadoServico();
        private CidadeServico cidadesServico = new CidadeServico();

        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricantesClassificadosPorNome());
        }


        private ActionResult ObterVisaoFabricantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        private void PopularViewBag(Fabricante fabricante = null)
        {
            if (fabricante == null)
            {
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadosPorNome(), "FabricanteId", "Nome", fabricante.FabricanteId);
            }
        }

        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }
        }

        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(estadosServico.ObterEstadosClassificadosPorNome(), "EstadoID", "Nome");
            ViewBag.CidadeID = new SelectList(cidadesServico.ObterCidadesPorEstado(null), "CidadeID", "Nome");

            PopularViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                fabricanteServico.GravarFabricante(fabricante);
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        public ActionResult Edit(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
            if(fabricante == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(estadosServico.ObterEstadosClassificadosPorNome(), "EstadoID", "Nome", fabricante.EstadoID);
            ViewBag.CidadeID = new SelectList(cidadesServico.ObterCidadesPorEstado(fabricante.EstadoID), "CidadeID", "Nome", fabricante.CidadeID);
            PopularViewBag(fabricanteServico.ObterFabricantePorId((long) id));
            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                fabricanteServico.GravarFabricante(fabricante);
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoFabricantePorId((long)id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Fabricante fabricante = fabricanteServico.RemoverFabricante(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}