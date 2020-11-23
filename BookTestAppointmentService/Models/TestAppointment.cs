using System;
using System.Collections.Generic;

#nullable disable

namespace BookTestAppointmentService
{
    public partial class TestAppointment
    {
        public int BookingId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PaymentType { get; set; }
    }
}
