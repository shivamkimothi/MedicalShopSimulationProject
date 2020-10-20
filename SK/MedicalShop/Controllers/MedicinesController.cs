using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalShop.Models;
using MedicalShop.Services;
using MedicalShop.Services.MedicineService;
using Microsoft.AspNetCore.Authorization;

namespace MedicalShop.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        // private static medicalShopContext _context = new medicalShopContext();

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MedicinesController));
        private IMedicineService _medicineService;

        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
            
        }
        

        /*public MedicinesController(medicalShopContext context)
        {
            _context = context;
        }*/


        // GET: api/Medicines
        [HttpGet]
        public ActionResult<IEnumerable<Medicine>> GetMedicine()
        {
            return Ok(_medicineService.GetMedicine());
            //return await _context.Medicine.ToListAsync();
        }

        // GET: api/Medicines/5
        [HttpGet("{id}")]
        public ActionResult<Medicine> GetMedicine(int id)
        {
            /*var medicine = await _context.Medicine.FindAsync(id);

            if (medicine == null)
            {
                return NotFound();
            }

            return medicine;*/
            IQueryable<Medicine> medicine = (IQueryable<Medicine>)_medicineService.GetMedicine(id);
            if (medicine.Count() == 0)
            {
                return BadRequest();
            }
            return Ok(medicine);

        }

        // PUT: api/Medicines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutMedicine(int id, Medicine medicine)
        {
            if (id != medicine.Mid)
            {
                return BadRequest();
            }

           // _context.Entry(medicine).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                _medicineService.PutMedicine(id, medicine);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Medicines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Medicine> PostMedicine(Medicine medicine)
        {
            //_context.Medicine.Add(medicine);
            try
            {
                var x = _medicineService.PostMedicine(medicine);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicineExists(medicine.Mid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicine", new { id = medicine.Mid }, medicine);
            //return Ok(_medicineService.PostMedicine(medicine));        
        }

        // DELETE: api/Medicines/5
        [HttpDelete("{id}")]
        public ActionResult<Medicine> DeleteMedicine(int id)
        {
            IQueryable<Medicine> medicine = (IQueryable<Medicine>)_medicineService.DeleteMedicine(id);
            if (medicine.Count() == 0)
            {
                return BadRequest();
            }
            /*var medicine = await _context.Medicine.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }

            _context.Medicine.Remove(medicine);
            await _context.SaveChangesAsync();

            return medicine;*/
            return Ok(medicine);
        }

        private bool MedicineExists(int id)
        {
            var x = _medicineService.GetMedicine(id).FirstOrDefault();
            if (x != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return _medicineService.MedicineExists(id);
            //return _context.Medicine.Any(e => e.Mid == id);
        }
    }
}
