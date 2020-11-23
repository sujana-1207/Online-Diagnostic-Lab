using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AuthService.Repository;
using AuthService;
using System.Configuration;

namespace AuthServiceTest
{
    public class Tests
    {
        List<User> users = new List<User>();
        IQueryable<User> userData;
        Mock<DiagnosticLabContext> mockContext;
        Mock<DbSet<User>> mockSet;

        [SetUp]
        public void Setup()
        {
            users= new List<User>()
            {   
                new User{Username="sujana",Password="psujana"}
            };
            userData = users.AsQueryable();
            mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            mockContext = new Mock<DiagnosticLabContext>();
            mockContext.Setup(x => x.Users).Returns(mockSet.Object);
        }

        [Test]
        public void LoginPass()
        {
            var userRepo = new LoginRepository(mockContext.Object);
            var user = userRepo.GetUser("sujana");
            var expected = new User { Username = "sujana", Password = "psujana" };
            Assert.AreEqual(user.Password, expected.Password);

        }
        [Test]
        public void LoginFail()
        {
            var userRepo = new LoginRepository(mockContext.Object);
            var user = userRepo.GetUser("sujana");
            var expected = new User {Username="suja",Password="psujana" };
            Assert.AreEqual(user.Password, expected.Password);
            Assert.AreEqual(user.Username, expected.Username);

        }

    }
}