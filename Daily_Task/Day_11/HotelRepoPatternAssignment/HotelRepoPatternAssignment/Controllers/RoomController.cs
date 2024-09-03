using HotelRepoPatternAssignment.Models;
using HotelRepoPatternAssignment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelRepoPatternAssignment.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoom _ser;
        private readonly IHotel _serhotel;
        public RoomController(IRoom ser, IHotel serhotel)
        {
            _ser = ser;
            _serhotel = serhotel;
        }
        public IActionResult Index()
        {
            IEnumerable<Room> r = _ser.GetAll();
            return View(r);
        }

        public IActionResult Details(int id)
        {
            Room r = _ser.GetRoom(id);
            return View(r);
        }
        public ActionResult Create()
        {
            ViewBag.HotelId = new SelectList(_serhotel.GetAll(), "HotelId", "HotelName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room r)
        {
            ViewBag.HotelId = new SelectList(_serhotel.GetAll(), "HotelId", "HotelName", r.HotelId);
            _ser.AddRoom(r);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            ViewBag.HotelId = new SelectList(_serhotel.GetAll(), "HotelId", "HotelName");
            Room r = _ser.GetRoom(id);
            return View(r);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Room r)
        {
            //ViewBag.HotelId = new SelectList(_serhotel.GetAll(), "HotelId", "HotelName", r.HotelId);
            Room temp = _ser.UpdateRoom(id, r);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            ViewBag.HotelId = new SelectList(_serhotel.GetAll(), "HotelId", "HotelName");
            Room r = _ser.GetRoom(id);
            return View(r);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Room r)
        {

            _ser.DeleteRoom(r);
            return RedirectToAction(nameof(Index));
        }
    }
}
