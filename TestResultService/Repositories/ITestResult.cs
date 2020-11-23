using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestResultService.Repositories
{
    public interface ITestResult
    {
        public List<TestResultsTab> GetAll();
        public TestResultsTab GetTestResult(int id);
    }
}
