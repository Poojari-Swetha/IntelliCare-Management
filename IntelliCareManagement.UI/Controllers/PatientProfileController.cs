using Microsoft.AspNetCore.Mvc;
using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;

using System.Threading.Tasks;


namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientProfileController : ControllerBase
    {
        private readonly IPatientProfileRepository _patientRepository;

        public PatientProfileController(IPatientProfileRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientRepository.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PatientDto dto)
        {
            await _patientRepository.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.PatientID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientDto dto)
        {
            if (id != dto.PatientID) return BadRequest();
            await _patientRepository.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
