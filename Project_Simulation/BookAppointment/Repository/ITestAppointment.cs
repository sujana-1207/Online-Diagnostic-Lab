using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAppointment.Repository
{
    public interface ITestAppointment
    {
        public List<TestAppointment> Get();
        public int BookAppointment(TestAppointment t);
    }
}
