using Clinic.API.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private AppDbContext _context;

        public MedicineController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Models.Clinic>> Clinic()
        {
            return await _context.Clinic.ToListAsync();
        }

        [HttpPost]

        public async Task<IActionResult> Clinic(Models.Clinic clinic)
        {
            var clinic1 = new Models.Clinic
            {
                Name = clinic.Name,
                Email = clinic.Email,
                Adress = clinic.Adress,
                Phone = clinic.Phone,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };
            await _context.Clinic.AddAsync(clinic1);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
