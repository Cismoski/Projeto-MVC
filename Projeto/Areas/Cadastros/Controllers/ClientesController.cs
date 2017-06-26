using System.Web.Mvc;
using Modelo.Cadastros;
using System.Net;
using Servico.Cadastros;


namespace Projeto.Areas.Cadastros.Controllers   
{
    public class ClientesController : Controller
    {
        private ClienteServico clienteServico = new ClienteServico();


        // GET: Clientes
        public ActionResult Index()
        {
            return View(clienteServico.ObterClientesClassificadosPorNome());
        }

        public ActionResult Create()
        {
            return View();
        }

        private ActionResult ObterVisaoClientePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteServico.ObterClientePorId((long)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        private ActionResult GravarCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteServico.GravarCliente(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            return GravarCliente(cliente);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoClientePorId((long)id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Cliente cliente = clienteServico.RemoverCliente(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoClientePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            return GravarCliente(cliente);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoClientePorId((long)id);
        }
    }
}