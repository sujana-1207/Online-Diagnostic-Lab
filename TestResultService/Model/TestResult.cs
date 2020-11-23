using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestResultService.Model
{
    public class TestResult
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Result { get; set;     }
    }
}
