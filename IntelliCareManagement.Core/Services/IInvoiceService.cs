using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{


    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync();
        Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId);
        Task AddInvoiceAsync(InvoiceDto invoice);
        Task UpdateInvoiceAsync(InvoiceDto invoice);
        Task DeleteInvoiceAsync(int invoiceId);
    }

}
