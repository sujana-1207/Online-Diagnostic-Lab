using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTestAppointmentService.Repositories
{
    public class AppointmentRepository:IAppointment
    {
        private static DiagnosticLabContext _context;
        public AppointmentRepository()
        {
            _context = new DiagnosticLabContext();
        }
        public AppointmentRepository(DiagnosticLabContext context)
        {
            _context = context;
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
