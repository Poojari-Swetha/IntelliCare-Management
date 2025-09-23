using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IInvoiceRepository
    {
        Task<IEnumerable<InvoiceDto>> GetAllAsync();
        Task<InvoiceDto> GetByIdAsync(int invoiceId);
        Task AddAsync(InvoiceDto invoice);
        Task UpdateAsync(InvoiceDto invoice);
        Task DeleteAsync(int invoiceId);
    }

}
