using Microsoft.AspNetCore.Mvc;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Core.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IntelliCareManagement.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InvoiceDto invoiceDto)
        {
            await _invoiceRepository.AddAsync(invoiceDto);
            return CreatedAtAction(nameof(GetById), new { id = invoiceDto.InvoiceID }, invoiceDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InvoiceDto invoiceDto)
        {
            if (id != invoiceDto.InvoiceID) return BadRequest();
            await _invoiceRepository.UpdateAsync(invoiceDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _invoiceRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}