using AuthenticationApi;
using AuthenticationApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AuthneticationApiNUnit
{
    public class Tests
    {
        public List<Users> obj1 = new List<Users>()
        {
            new Users
            {
                Email = "admin",
                Password = "admin"
            }
        };
        TokenController s = new TokenController();
        [SetUp]
        public void Setup()
        {
            var details = obj1.AsQueryable();
            var mockset = new Mock<Users>();
            mockset.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(details.Provider);
            mockset.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(details.Expression);
            mockset.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(details.ElementType);
            mockset.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(details.GetEnumerator());
        }

        [Test]
        public void Login()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            config.Setup(p => p["Jwt:Key"]).Returns("ThisismySecretKey");
            TokenController controller = new TokenController(config.Object);
            var auth = controller.Login(new Users { Email = "admin", Password = "admin" }) as OkObjectResult;

            Assert.AreEqual(200, auth.StatusCode);
            Users user = new Users{ Email = "admin", Password = "admin"};
            var result = s.Login(user);
            Assert.IsNotNull(result);
        }
    }
}
/*public class Tests
    {
        public List<Medicine> obj1 = new List<Medicine>()
            {
                new Medicine
                {
                    Mid = 134, 
                    Mname = "rectocyn",
                   // ExpiryDate = new System.DateTime(2028-12-31), 
                    Price = 78, 
                    QuantityRemaining = 45
                }
            };
        //Simulation_dbContext xx = new Simulation_dbContext();
        MedicineService obj2 = new MedicineService();
        [SetUp]
        public void Setup()
        {
            var details = obj1.AsQueryable();
            var mockset = new Mock<Medicine>();
            mockset.As<IQueryable<Medicine>>().Setup(m => m.Provider).Returns(details.Provider);
            mockset.As<IQueryable<Medicine>>().Setup(m => m.Expression).Returns(details.Expression);
            mockset.As<IQueryable<Medicine>>().Setup(m => m.ElementType).Returns(details.ElementType);
            mockset.As<IQueryable<Medicine>>().Setup(m => m.GetEnumerator()).Returns(details.GetEnumerator());
        }

        [Test]
        public void Test1()
        {
            var result = obj2.GetMedicine();
            var type1 = result;
            // Console.WriteLine(result);
            // Console.WriteLine(iptreatment);

            var type2 = obj1 as List<Medicine>;
            Assert.IsNotNull(type1);
            Assert.Pass();
        }
    }*/