using NUnit.Framework;
using Moq;
using TestResultService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestResultService.Repositories;
using TestResultService.Controllers;

namespace TestResultServiceTest
{
    public class Tests
    {
        List<TestResultsTab> results = new List<TestResultsTab>();
        IQueryable<TestResultsTab> resultData;
        Mock<DiagnosticLabContext> mockContext;
        Mock<DbSet<TestResultsTab>> mockSet;
        [SetUp]
        public void Setup()
        {
            results = new List<TestResultsTab>()
            {
                new TestResultsTab{TestId= 1, UserId=101,UserName="Sujana",Result="Negative"},
                new TestResultsTab{TestId= 2, UserId=102,UserName="Mother Gothel",Result="Positive"}

            };
            resultData = results.AsQueryable();
            mockSet = new Mock<DbSet<TestResultsTab>>();
            mockSet.As<IQueryable<TestResultsTab>>().Setup(m => m.Provider).Returns(resultData.Provider);
            mockSet.As<IQueryable<TestResultsTab>>().Setup(m => m.Expression).Returns(resultData.Expression);
            mockSet.As<IQueryable<TestResultsTab>>().Setup(m => m.ElementType).Returns(resultData.ElementType);
            mockSet.As<IQueryable<TestResultsTab>>().Setup(m => m.GetEnumerator()).Returns(resultData.GetEnumerator());
  
            mockContext = new Mock<DiagnosticLabContext>();
            mockContext.Setup(x => x.TestResultsTabs).Returns(mockSet.Object);
        }

        [Test]
        public void GetTestResultsCorrect()
        {
            var resultrepo = new TestResultRepository(mockContext.Object);
            var actualResult = resultrepo.GetTestResult(2);
            TestResultsTab expectedResult = new TestResultsTab();
            expectedResult.TestId = 2;
            expectedResult.UserId = 102;
            expectedResult.UserName = "Mother Gothel";
            expectedResult.Result = "Positive";
            Assert.AreEqual(expectedResult.TestId, actualResult.TestId);
            Assert.AreEqual(expectedResult.UserId, actualResult.UserId);
            Assert.AreEqual(expectedResult.UserName, actualResult.UserName);
            Assert.AreEqual(expectedResult.Result, actualResult.Result);
            Assert.Pass();
        }
        [Test]
        public void GetTestResultsWrong()
        {
            var resultrepo = new TestResultRepository(mockContext.Object);
            var actualResult = resultrepo.GetTestResult(2);
            TestResultsTab expectedResult = new TestResultsTab();
            expectedResult.TestId = 2;
            expectedResult.UserId = 1022;
            expectedResult.UserName = "Mother Gothel";
            expectedResult.Result = "Poitive";
            Assert.AreEqual(expectedResult.TestId, actualResult.TestId);
            Assert.AreNotEqual(expectedResult.UserId, actualResult.UserId);
            Assert.AreEqual(expectedResult.UserName, actualResult.UserName);
            Assert.AreNotEqual(expectedResult.Result, actualResult.Result);
            Assert.Pass();
        }
    }
}