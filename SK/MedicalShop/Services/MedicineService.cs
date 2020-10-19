using MedicalShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MedicalShop.Services.MedicineService
{
    public class MedicineService : IMedicineService
    {
        private readonly medicalShopContext _context;

       
        public MedicineService(medicalShopContext context)
        {
            _context = context;
        }

        
        public IQueryable<Medicine> DeleteMedicine(int id)
        {
            //var medicine = await _context.Medicine.FindAsync(id);

            IQueryable<Medicine> medicine = _context.Medicine.Where(p => p.Mid == id);
            _context.Medicine.Remove(medicine.FirstOrDefault());
            _context.SaveChangesAsync();

            return medicine;
        }

        public List<Medicine> GetMedicine()
        {
            return _context.Medicine.ToList();
        }

        public IQueryable<Medicine> GetMedicine(int id)
        {
            return _context.Medicine.Where(p => p.Mid == id);
        }

        public bool MedicineExists(int id)
        {
            return _context.Medicine.Any(e => e.Mid == id);
            throw new NotImplementedException();
        }

        public Medicine PostMedicine(Medicine medicine)
        {
            _context.Medicine.Add(medicine);
            _context.SaveChangesAsync();
            return medicine;
        }

        public Medicine PutMedicine(int id, Medicine medicine)
        {

            _context.Entry(medicine).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return medicine;
        }
    }
}
