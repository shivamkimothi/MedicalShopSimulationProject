using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OrdersApi.Models;
using OrdersApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrdersApiNUnit
{
    public class Tests
    {

        List<Orders> meds = new List<Orders>();
        IQueryable<Orders> medicinedata;
        Mock<DbSet<Orders>> mockSet;
        Mock<medicalShopContext> medicinecontextmock;
        [SetUp]
        public void Setup()
        {

            meds = new List<Orders>()
            {

                new Orders{Mid = 123, Dateoforder=DateTime.Now, Oid = 12, Quantity = 45, Totalcost = 560},
                 //new Orders{Mid = 134, ExpiryDate=DateTime.Now, Mname = "Forever", Price=395, QuantityRemaining = 455}

            };
            medicinedata = meds.AsQueryable();
            mockSet = new Mock<DbSet<Orders>>();
            mockSet.As<IQueryable<Orders>>().Setup(m => m.Provider).Returns(medicinedata.Provider);
            mockSet.As<IQueryable<Orders>>().Setup(m => m.Expression).Returns(medicinedata.Expression);
            mockSet.As<IQueryable<Orders>>().Setup(m => m.ElementType).Returns(medicinedata.ElementType);
            mockSet.As<IQueryable<Orders>>().Setup(m => m.GetEnumerator()).Returns(medicinedata.GetEnumerator());
            var p = new DbContextOptions<medicalShopContext>();
            medicinecontextmock = new Mock<medicalShopContext>(p);
            medicinecontextmock.Setup(x => x.Orders).Returns(mockSet.Object);



        }


        [Test]
        public void GetAllMedicinesByUserIdTest()
        {
            var orderService = new OrderService(medicinecontextmock.Object);
            var medicinelist = orderService.GetOrders(123);
            Assert.AreEqual(1, medicinelist.Count());
        }

        [Test]
        public void AddMedicineDetailTest()
        {
            var orderService = new OrderService(medicinecontextmock.Object);
            var x = orderService.PostOrders(new Orders { Mid = 123, Dateoforder = DateTime.Now, Oid = 12, Quantity = 45, Totalcost = 560 });
            Assert.IsNotNull(x);

        }

        [Test]
        public void UpdateMedicineDetail()
        {
            var medicineService = new OrderService(medicinecontextmock.Object);
            var x = medicineService.PostOrders(new Orders { Mid = 123, Dateoforder = DateTime.Now, Oid = 12, Quantity = 45, Totalcost = 560 });
            Assert.IsNotNull(x);
        }

        [Test]
        public void DeleteMedicineDeatail()
        {
            var medicineService = new OrderService(medicinecontextmock.Object);
            var x = medicineService.DeleteOrders(1);
            Assert.IsNotNull(x);
        }
    }
}