using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        // GET: api/Document
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentDto>>> GetAll()
        {
            var documents = await _documentRepository.GetAllAsync();
            return Ok(documents);
        }

        // GET: api/Document/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDto>> GetById(int id)
        {
            var document = await _documentRepository.GetByIdAsync(id);
            if (document == null)
                return NotFound();
            return Ok(document);
        }

        // POST: api/Document
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] DocumentDto dto)
        {
            await _documentRepository.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.DocumentID }, dto);
        }

        // PUT: api/Document/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] DocumentDto dto)
        {
            if (id != dto.DocumentID)
                return BadRequest("Document ID mismatch.");

            await _documentRepository.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE: api/Document/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _documentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
