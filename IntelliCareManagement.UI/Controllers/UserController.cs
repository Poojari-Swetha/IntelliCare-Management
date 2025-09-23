using Microsoft.AspNetCore.Mvc;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Core.DTOs;
using System.Threading.Tasks;

namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDto dto)
        {
            await _userRepository.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.UserID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto dto)
        {
            if (id != dto.UserID) return BadRequest();
            await _userRepository.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
