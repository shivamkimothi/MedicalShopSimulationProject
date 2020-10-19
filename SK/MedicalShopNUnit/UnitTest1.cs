using MedicalShop.Controllers;
using MedicalShop.Models;
using MedicalShop.Services.MedicineService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalShopNUnit
{
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


    public class Tests
    {

        List<Medicine> meds = new List<Medicine>();
        IQueryable<Medicine> medicinedata;
        Mock<DbSet<Medicine>> mockSet;
        Mock<medicalShopContext> medicinecontextmock;
        [SetUp]
        public void Setup()
        {
            
            meds = new List<Medicine>()
            {

                new Medicine{Mid = 123, ExpiryDate=DateTime.Now, Mname = "Wakanda", Price=345, QuantityRemaining = 45},
                 new Medicine{Mid = 134, ExpiryDate=DateTime.Now, Mname = "Forever", Price=395, QuantityRemaining = 455}

            };
            medicinedata = meds.AsQueryable();
            mockSet = new Mock<DbSet<Medicine>>();
            mockSet.As<IQueryable<Medicine>>().Setup(m => m.Provider).Returns(medicinedata.Provider);
            mockSet.As<IQueryable<Medicine>>().Setup(m => m.Expression).Returns(medicinedata.Expression);
            mockSet.As<IQueryable<Medicine>>().Setup(m => m.ElementType).Returns(medicinedata.ElementType);
            mockSet.As<IQueryable<Medicine>>().Setup(m => m.GetEnumerator()).Returns(medicinedata.GetEnumerator());
            var p = new DbContextOptions<medicalShopContext>();
            medicinecontextmock = new Mock<medicalShopContext>(p);
            medicinecontextmock.Setup(x => x.Medicine).Returns(mockSet.Object);



        }


        [Test]
        public void GetAllMedicinesByUserIdTest()
        {
            var medicineService= new MedicineService(medicinecontextmock.Object);
            var medicinelist = medicineService.GetMedicine(123);
            Assert.AreEqual(1, medicinelist.Count());
        }
        
        [Test]
        public void AddMedicineDetailTest()
        {
            var medicineService = new MedicineService(medicinecontextmock.Object);
            var x = medicineService.PostMedicine(new Medicine{Mid = 23, ExpiryDate = DateTime.Now, Mname = "Walhabibi", Price = 345, QuantityRemaining = 5 });
            Assert.IsNotNull(x);

        }

        [Test]
        public void UpdateMedicineDetail()
        {
            var medicineService = new MedicineService(medicinecontextmock.Object);
            var x = medicineService.PostMedicine(new Medicine { Mid = 1, ExpiryDate = DateTime.Now, Mname = "Walhabibi", Price = 345, QuantityRemaining = 5 });
            Assert.IsNotNull(x);
        }

        [Test]
        public void DeleteMedicineDeatail()
        {
            var medicineService = new MedicineService(medicinecontextmock.Object);
            var x = medicineService.DeleteMedicine(1);
            Assert.IsNotNull(x);
        }
        /*
        [Test]
        public void AddBookingDetailTest()
        {
            var medicineService = new MedicineService(medicinecontextmock.Object);
            var medicinelist = medicineService.PostMedicine(new Medicine {});
            Assert.IsNotNull(medicinelist);
        }
        */
    }
}