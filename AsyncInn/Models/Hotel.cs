using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Hotel
    {
        // Model props
        public int ID { get; set; }

        [Required(ErrorMessage = "Hotel Name Required")]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
