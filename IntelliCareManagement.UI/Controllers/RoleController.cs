using Microsoft.AspNetCore.Mvc;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Core.DTOs;
using System.Threading.Tasks;

namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleRepository.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleDto roleDto)
        {
            await _roleRepository.AddAsync(roleDto);
            return CreatedAtAction(nameof(GetById), new { id = roleDto.RoleID }, roleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoleDto roleDto)
        {
            if (id != roleDto.RoleID) return BadRequest();
            await _roleRepository.UpdateAsync(roleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
