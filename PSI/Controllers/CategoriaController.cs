using Modelo.Tabelas;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Xml.Linq;
using Servico.Cadastros;
using Servico.Tabelas;



namespace PSI.Controllers

{
    public class CategoriasController : Controller
    {
        // private EFContext context = new EFContext();
        private CategoriaServico CategoriaServico = new CategoriaServico();

        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Categoria Categoria = CategoriaServico.ObterCategoriaPorId((long)id);
            if (Categoria == null)
            {
                return HttpNotFound();
            }
            return View(Categoria);
        }

        private ActionResult GravarCategoria(Categoria Categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoriaServico.GravarCategoria(Categoria);
                    return RedirectToAction("Index");
                }
                return View(Categoria);
            }
            catch
            {
                return View(Categoria);
            } //a
        }

        // GET: Categorias
        public ActionResult Index()
        {
            return View(CategoriaServico.ObterCategoriasClassificadasPorNome());
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria Categoria)
        {
            return GravarCategoria(Categoria);
        }
        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria Categoria)
        {
            return GravarCategoria(Categoria);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }



        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria Categoria = CategoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + Categoria.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}