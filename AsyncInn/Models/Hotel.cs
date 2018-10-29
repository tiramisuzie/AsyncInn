using System.Collections.Generic;

namespace AsyncInn.Models
{
    public class Hotel
    {
        // Model props
        public int ID { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        
        //public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
