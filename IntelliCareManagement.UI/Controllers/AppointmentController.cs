using Microsoft.AspNetCore.Mvc;
using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using System.Threading.Tasks;

namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppointmentDto dto)
        {
            await _appointmentRepository.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.AppointmentID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AppointmentDto dto)
        {
            if (id != dto.AppointmentID) return BadRequest();
            await _appointmentRepository.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
