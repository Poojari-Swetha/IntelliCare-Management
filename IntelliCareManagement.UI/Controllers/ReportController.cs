using Microsoft.AspNetCore.Mvc;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelliCareManagement.UI.Controllers
{
    // The [ApiController] attribute enables API-specific behaviors like automatic HTTP 400 responses.
    [ApiController]
    // The [Route] attribute defines the URL route for this controller.
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        // The constructor uses dependency injection to get an instance of the repository.
        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        // Handles GET requests to /api/Report
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetAll()
        {
            // Call the repository to get all reports.
            var reports = await _reportRepository.GetAllAsync();
            return Ok(reports);
        }

        // Handles GET requests to /api/Report/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDto>> GetById(int id)
        {
            // Call the repository to get a single report by ID.
            var report = await _reportRepository.GetByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        // Handles POST requests to /api/Report
        [HttpPost]
        public async Task<ActionResult> Add(ReportDto reportDto)
        {
            // Call the repository to add a new report.
            await _reportRepository.AddAsync(reportDto);
            // Return a 201 Created response.
            return CreatedAtAction(nameof(GetById), new { id = reportDto.ReportID }, reportDto);
        }

        // Handles PUT requests to /api/Report/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ReportDto reportDto)
        {
            // Check for a mismatch between the URL ID and the DTO ID.
            if (id != reportDto.ReportID)
            {
                return BadRequest();
            }

            // Call the repository to update the report.
            await _reportRepository.UpdateAsync(reportDto);
            return NoContent(); // Return 204 No Content for a successful update.
        }

        // Handles DELETE requests to /api/Report/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            // Call the repository to delete the report.
            await _reportRepository.DeleteAsync(id);
            return NoContent(); // Return 204 No Content for a successful deletion.
        }
    }
}
