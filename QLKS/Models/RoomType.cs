using System;

namespace QLKS.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string TypeName { get; set; } // Single, Double, Suite, Deluxe
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasKitchen { get; set; }
        public bool HasSeaView { get; set; }
    }
}
