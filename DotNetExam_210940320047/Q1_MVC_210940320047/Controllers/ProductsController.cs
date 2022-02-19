using _210940320047.Dao;
using _210940320047.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _210940320047.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDao dao = new ProductsDao();
        // GET: Products
        public ActionResult Index()
        {
            
            return View(dao.FetchAll());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id = -1)
        {
            Product p = null;
            if (id == -1 || (p = dao.getProductById(id)) == null)
                return RedirectToAction("Index");
            return View(p);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product p)
        {
                p.ProductId = id;
            try
            {
                dao.Update(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(p);
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return View();
        }
    }
}
