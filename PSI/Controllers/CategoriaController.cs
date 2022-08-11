using PSI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PSI.Controllers
{
    public class CategoriasController : Controller
    {
        public EFContext context = new EFContext();
        //private static IList<Categoria> categorias = new List<Categoria>()
        //{
        //    new Categoria() { CategoriaId = 1, Nome = "Notebooks"},
        //    new Categoria() { CategoriaId = 2, Nome = "Monitores"},
        //    new Categoria() { CategoriaId = 3, Nome = "Impressoras"},
        //    new Categoria() { CategoriaId = 4, Nome = "Mouses"},
        //    new Categoria() { CategoriaId = 5, Nome = "Desktops"}
        //};

        // GET: Categorias
        public ActionResult Index() => View(context.Categorias.OrderBy(c => c.Nome));

        // GET: Categorias
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            //categorias.Add(categoria);
            //categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
#pragma warning disable CS0472 // O resultado da expressão é sempre o mesmo, pois um valor deste tipo nunca é 'null' 
            if (id == null)
#pragma warning restore CS0472 // O resultado da expressão é sempre o mesmo, pois um valor deste tipo nunca é 'null' 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                


                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);

            //Fabricante fabricante = fabricantes.Where(m => m.FabricanteId == id).First();
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            //categorias.Remove(
            //categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();

            TempData["Message"] = "Fabricante " + categoria.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}