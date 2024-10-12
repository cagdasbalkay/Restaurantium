using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Entities
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public byte NumberOfGuests { get; set; }
        public string SpecialRequest { get; set; }

    }
}
