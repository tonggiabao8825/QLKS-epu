using System;
using System.Collections.Generic;
using QLKS.Models;
using QLKS.DAL;

namespace QLKS.Controllers
{
    public class RoomController
    {
        private RoomDAL roomDAL;

        public RoomController()
        {
            roomDAL = new RoomDAL();
        }

        public List<Room> GetAllRooms()
        {
            return roomDAL.GetAll();
        }

        public Room GetRoomById(int id)
        {
            return roomDAL.GetById(id);
        }

        public bool AddRoom(Room room)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(room.RoomNumber))
            {
                throw new Exception("Số phòng không được để trống");
            }

            room.CreatedDate = DateTime.Now;
            return roomDAL.Insert(room);
        }

        public bool UpdateRoom(Room room)
        {
            room.UpdatedDate = DateTime.Now;
            return roomDAL.Update(room);
        }

        public bool DeleteRoom(int id)
        {
            return roomDAL.Delete(id);
        }

        public List<Room> SearchRooms(string keyword)
        {
            return roomDAL.Search(keyword);
        }

        public List<Room> GetRoomsByStatus(string status)
        {
            return roomDAL.GetByStatus(status);
        }
    }
}
