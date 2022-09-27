using doctorsAPI.Data;
using doctorsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace doctorsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : Controller
    {
        private readonly DataDbContext _dataDbContext;
        public DoctorsController(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }


        [HttpGet]
        public async Task <IActionResult> GetAllDoctors()
        {
            var doctors = await _dataDbContext.Doctors.ToListAsync();

            return Ok(doctors);
        }

        [HttpPost]

        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctorRequest)
        {
            doctorRequest.Id = Guid.NewGuid();

            await _dataDbContext.Doctors.AddAsync(doctorRequest);
            await _dataDbContext.SaveChangesAsync();

            return Ok(doctorRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetDoctor([FromRoute] Guid id)
        {
            

            var doctor = await _dataDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            
            if (doctor == null)
            {
                return NotFound();
            }
           

            return Ok(doctor);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDoctor([FromRoute] Guid id, Doctor updateDoctorRequest)
        {
           var doctor = await _dataDbContext.Doctors.FindAsync(id);

            if (doctor == null )
            {
                return NotFound();
            }

            doctor.Position = updateDoctorRequest.Position;
            doctor.FirstName = updateDoctorRequest.FirstName;
            doctor.LastName = updateDoctorRequest.LastName;
            doctor.Place = updateDoctorRequest.Place;

            await _dataDbContext.SaveChangesAsync();

            return Ok(doctor);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteDoctor([FromRoute] Guid id)
        {

            var doctor = await _dataDbContext.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _dataDbContext.Doctors.Remove(doctor);
            await _dataDbContext.SaveChangesAsync();

            return Ok(doctor);
        }
    }
}
