using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Room Name Required")]
        [Display(Name = "Room Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Layout Required")]
        [EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }
        
        public ICollection<HotelRoom> HotelRooms { get; set; }

        public ICollection<RoomAmenity> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        [Display(Name = "Studio")]
        Studio,
        [Display(Name = "1 Bedroom")]
        OneBedroom,
        [Display(Name = "2 Bedroom")]
        TwoBedroom
    }
}
