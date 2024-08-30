using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcefcodefirst.Models;

namespace mvcefcodefirst.Controllers
{
    public class OrdersController : Controller
    {
        private readonly CustomerDbContext _Context;
        public OrdersController(CustomerDbContext context)
        {
            _Context = context;
        }

        // GET: OrderController1
        public ActionResult Index()
        {
            IEnumerable<Order> ords = _Context.Order.Include(c => c.Customer).ToList();
            return View(ords);
        }

        // GET: OrderController1/Details/5
        public ActionResult Details(int id)
        {
            Order or = _Context.Order.Include(c => c.Customer).FirstOrDefault(o => o.OrderId == id) ?? new Order();
            return View(or);
        }

        // GET: OrderController1/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(_Context.Customers, "id", "id");

            return View();
        }

        // POST: OrderController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order o)
        {
            try
            {
                ViewBag.id = new SelectList(_Context.Customers, "id", "id",o.id);
                _Context.Add(o);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
