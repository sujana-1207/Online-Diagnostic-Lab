using System;
using System.Collections.Generic;

#nullable disable

namespace TestResultService
{
    public partial class TestAppointment
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PaymentType { get; set; }
    }
}
