using HotelRepoPatternAssignment.Models;
using HotelRepoPatternAssignment.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelRepoPatternAssignment.Service
{
    public class RoomService : IRoom
    {
        private readonly HotelContext _contxt;
        public RoomService(HotelContext contxt)
        {
            _contxt = contxt;
        }
        public IEnumerable<Room> GetAll()
        {
            return _contxt.Rooms.Include(h => h.Hotel).ToList();
        }
        public Room? GetRoom(int id)
        {
            return _contxt.Rooms.Include(h => h.Hotel).FirstOrDefault(s => s.RoomNo == id);
        }
        public void AddRoom(Room r)
        {
            _contxt.Add(r);
            _contxt.SaveChanges();
        }
        public Room UpdateRoom(int id, Room r)
        {
            _contxt.Update(r);
            _contxt.SaveChanges();
            return r;
        }
        public void DeleteRoom(Room r)
        {
            _contxt.Remove(r);
            _contxt.SaveChanges();
        }
    }
}
