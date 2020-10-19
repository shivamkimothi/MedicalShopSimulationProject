using MedicalShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShop.Services.MedicineService
{
    public interface IMedicineService
    {
        public List<Medicine> GetMedicine();
        public IQueryable<Medicine> GetMedicine(int id);
        public Medicine PutMedicine(int id, Medicine medicine);
        public Medicine PostMedicine(Medicine medicine);
        public IQueryable<Medicine> DeleteMedicine(int id);
        public bool MedicineExists(int id);
    }
}
