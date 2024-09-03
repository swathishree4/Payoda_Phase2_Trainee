using HotelRepoPatternAssignment.Models;
using HotelRepoPatternAssignment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelRepoPatternAssignment.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotel _ser;
        public HotelController(IHotel ser)
        {
            _ser = ser;
        }
        public IActionResult Index()
        {
            IEnumerable<Hotel> h = _ser.GetAll();
            return View(h);
        }
        public IActionResult Details(int id)
        {
            Hotel h = _ser.GetHotel(id);
            return View(h);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel h)
        {
            _ser.AddHotel(h);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int id)
        {
            Hotel h = _ser.GetHotel(id);
            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hotel h)
        {
            _ser.UpdateHotel(id, h);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            Hotel h = _ser.GetHotel(id);
            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hotel h)
        {
            _ser.DeleteHotel(h);
            return RedirectToAction(nameof(Index));
        }
    }
}
