using Microsoft.AspNetCore.Mvc;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Core.DTOs;
using System.Threading.Tasks;

namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DoctorDto doctorDto)
        {
            await _doctorRepository.AddAsync(doctorDto);
            return CreatedAtAction(nameof(GetById), new { id = doctorDto.DoctorID }, doctorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DoctorDto doctorDto)
        {
            if (id != doctorDto.DoctorID) return BadRequest();
            await _doctorRepository.UpdateAsync(doctorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _doctorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
