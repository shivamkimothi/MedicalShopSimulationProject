using AuthenticationApi;
using AuthenticationApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationApiNUnit
{
    public class Tests
    {
        List<Users> user = new List<Users>();
        IQueryable<Users> userdata;
        Mock<Users> mockSet;
        [SetUp]
        public void Setup()
        {
            user = new List<Users>()
            {
                new Users{Email="admin",Password="admin"}

            };
            userdata = user.AsQueryable();
            mockSet = new Mock<Users>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(userdata.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(userdata.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(userdata.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(userdata.GetEnumerator());
            /*var p = new DbContextOptions<UserDbContext>();
            usercontextmock = new Mock<UserDbContext>(p);
            usercontextmock.Setup(x => x.Users).Returns(mockSet.Object);*/



        }


        [Test]
        public void LoginTestPass()
        {

            Mock<IConfiguration> config = new Mock<IConfiguration>();
            config.Setup(p => p["Jwt:Key"]).Returns("ThisismySecretKey");
            TokenController controller = new TokenController(config.Object);
            var auth = controller.Login(new Users { Email = "admin", Password = "admin" }) as OkObjectResult;

            Assert.AreEqual(200, auth.StatusCode);






        }

        [Test]
        public void LoginTestFail()
        {

            Mock<IConfiguration> config = new Mock<IConfiguration>();
            config.Setup(p => p["Jwt:Key"]).Returns("ThisismySecretKey");
            TokenController controller = new TokenController(config.Object);
            var auth = controller.Login(new Users { Email = "admin", Password = "wakanda" }) as OkObjectResult;

            Assert.IsNull(auth);






        }
    }
}