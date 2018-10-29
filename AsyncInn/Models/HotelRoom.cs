using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        [ForeignKey("Hotel")]
        [Display(Name = "Hotel")]
        public int HotelID { get; set; }

        [ForeignKey("Room")]
        [Display(Name = "Room")]
        public int RoomID { get; set; }

        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Nightly Rate Required")]
        [Display(Name = "Nightly Rate")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Is It Pet Friendly?")]
        [Display(Name = "Pet Friendly?")]
        public bool PetFriendly { get; set; }
        
        public Hotel Hotel { get; set; }

        public Room Room { get; set; }
    }
}
