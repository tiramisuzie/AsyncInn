using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInn.Models
{
    public class RoomAmenity
    {
        public int AmenityID { get; set; }

        [ForeignKey("Room")]
        [Display(Name = "Room")]
        public int RoomID { get; set; }

        [ForeignKey("Amenity")]
        [Display(Name = "Amenity")]
        public int AmenitiesID { get; set; }

        public Room Room { get; set; }
    }
}
