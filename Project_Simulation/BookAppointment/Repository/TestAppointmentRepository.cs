using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAppointment.Repository
{
    public class TestAppointmentRepository:ITestAppointment
    {
        private static DiagnosticLabContext _context;
        public TestAppointmentRepository()
        {
            _context = new DiagnosticLabContext();
        }
        public List<TestAppointment> Get()
        {
            return _context.TestAppointments.ToList();
        }
        public int BookAppointment(TestAppointment t)
        {
            try
            {
                _context.TestAppointments.Add(t);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
