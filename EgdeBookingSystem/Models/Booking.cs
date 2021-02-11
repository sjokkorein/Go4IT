using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgdeBookingSystem.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public Equipment Equipment { get; set; }
        public BookingTime BookingTime { get; set; }

        //public Customer Customer { get; set; }
    }
}
