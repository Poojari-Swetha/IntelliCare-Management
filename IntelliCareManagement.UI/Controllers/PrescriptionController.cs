using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionController(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        // GET: api/Prescription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescriptionDto>>> GetAll()
        {
            var prescriptions = await _prescriptionRepository.GetAllAsync();
            return Ok(prescriptions);
        }

        // GET: api/Prescription/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionDto>> GetById(int id)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id);
            if (prescription == null)
                return NotFound();
            return Ok(prescription);
        }

        // POST: api/Prescription
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PrescriptionDto dto)
        {
            await _prescriptionRepository.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.PrescriptionID }, dto);
        }

        // PUT: api/Prescription/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PrescriptionDto dto)
        {
            if (id != dto.PrescriptionID)
                return BadRequest("Prescription ID mismatch.");

            await _prescriptionRepository.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE: api/Prescription/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _prescriptionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
