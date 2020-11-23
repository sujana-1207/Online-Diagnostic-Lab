using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BookTestAppointmentService.Repositories;
using BookTestAppointmentService;

namespace BookAppointmentTest
{
    public class Tests
    {

        List<TestAppointment> results = new List<TestAppointment>();
        IQueryable<TestAppointment> resultData;
        Mock<DiagnosticLabContext> mockContext;
        Mock<DbSet<TestAppointment>> mockSet;

        [SetUp]
        public void Setup()
        {
            mockSet = new Mock<DbSet<TestAppointment>>();
            mockContext = new Mock<DiagnosticLabContext>();
            mockContext.Setup(x => x.TestAppointments).Returns(mockSet.Object);
        }

        [Test]
        public void BookAppointCorrect()
        {
            var resultrepo = new AppointmentRepository(mockContext.Object);
            var details = new TestAppointment {Firstname = "Sujana", Lastname = "Maruvada",PaymentType="Card" };
            var res = resultrepo.BookAppointment(details);
            Assert.AreEqual(1, res);
        }
    }
}