using Microsoft.AspNetCore.Mvc;
using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using System.Threading.Tasks;

namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserSecurityController : ControllerBase
    {
        private readonly IUserSecurityRepository _userSecurityRepository;

        public UserSecurityController(IUserSecurityRepository userSecurityRepository)
        {
            _userSecurityRepository = userSecurityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _userSecurityRepository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _userSecurityRepository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserSecurityDto dto)
        {
            await _userSecurityRepository.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.SecurityID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserSecurityDto dto)
        {
            if (id != dto.SecurityID) return BadRequest();
            await _userSecurityRepository.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userSecurityRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
