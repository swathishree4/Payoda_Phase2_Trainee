using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCADO.Dataacess;
using MVCADO.Models;

namespace MVCADO.Controllers
{
    public class ProductssController : Controller
    {
        Productdataacess obj=new Productdataacess();
        // GET: ProductssController
        public ActionResult Index()
        {
            IEnumerable<Product> products = obj.Fetch();
            return View(products);
            
        }

        // GET: ProductssController/Details/5
        public ActionResult Details(int id)
        {
            Product p = obj.Search(id);
            return View(p);
        }

        // GET: ProductssController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductssController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            try
            {
                obj.Insert(p);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductssController/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = obj.Search(id);
            return View(p);
        }

        // POST: ProductssController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Product p)
        {
            try
            {
                obj.Update(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductssController/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = obj.Search(id);
            return View(p);
        }

        // POST: ProductssController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Product p)
        {
            try
            {
                obj.Delete(id,p);  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
