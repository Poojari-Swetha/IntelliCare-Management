using Microsoft.AspNetCore.Mvc;
using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using System.Threading.Tasks;

namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationRepository _consultationRepository;

        public ConsultationController(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consultations = await _consultationRepository.GetAllAsync();
            return Ok(consultations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var consultation = await _consultationRepository.GetByIdAsync(id);
            if (consultation == null) return NotFound();
            return Ok(consultation);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConsultationDto dto)
        {
            await _consultationRepository.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.ConsultationID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ConsultationDto dto)
        {
            if (id != dto.ConsultationID) return BadRequest();
            await _consultationRepository.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _consultationRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
