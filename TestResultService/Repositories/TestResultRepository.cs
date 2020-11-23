using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestResultService.Repositories
{
    public class TestResultRepository : ITestResult
    {
        private static DiagnosticLabContext _context;
        public TestResultRepository()
        {
            _context = new DiagnosticLabContext();
        }
        public TestResultRepository(DiagnosticLabContext context)
        {
            _context = context;
        }
        public List<TestResultsTab>GetAll()
        {
            return _context.TestResultsTabs.ToList();
        }
        public TestResultsTab GetTestResult(int id)
        {
            var res = _context.TestResultsTabs.Where(c=>c.TestId==id).FirstOrDefault();
            return res;
        }

    }
}
