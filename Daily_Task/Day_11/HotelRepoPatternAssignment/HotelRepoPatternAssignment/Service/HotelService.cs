using HotelRepoPatternAssignment.Models;
using HotelRepoPatternAssignment.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelRepoPatternAssignment.Service
{
    public class HotelService:IHotel
    {
        private readonly HotelContext _contxt;
        public HotelService(HotelContext contxt)
        {
            _contxt = contxt;
        }
        public IEnumerable<Hotel> GetAll()
        {
            return _contxt.Hotels.Include(r => r.Rooms).ToList();
        }

        public Hotel? GetHotel(int id)
        {
            return _contxt.Hotels.FirstOrDefault(s => s.HotelId == id);
        }

        public void AddHotel(Hotel h)
        {
            _contxt.Add(h);
            _contxt.SaveChanges();
        }
        public Hotel UpdateHotel(int id, Hotel h)
        {
            _contxt.Update(h);
            _contxt.SaveChanges();
            return h;
        }
        public void DeleteHotel(Hotel h)
        {
            _contxt.Remove(h);
            _contxt.SaveChanges();
        }
    }
}
