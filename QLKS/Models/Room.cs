using System;

namespace QLKS.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public int Floor { get; set; }
        public decimal PricePerNight { get; set; }
        public string Status { get; set; } // Available, Occupied, Maintenance, Reserved
        public string Description { get; set; }
        public int MaxOccupancy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
