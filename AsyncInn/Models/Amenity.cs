using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Amenity
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Amenity Name Requires")]
        [Display(Name = "Amenity")]
        public string Name { get; set; }

        public ICollection<RoomAmenity> RoomAmenities { get; set; }
    }
}
