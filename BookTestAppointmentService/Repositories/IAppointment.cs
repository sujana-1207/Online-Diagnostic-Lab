using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTestAppointmentService.Repositories
{
    public interface IAppointment
    {
        public List<TestAppointment> Get();
        public int BookAppointment(TestAppointment t);
    }
}
