using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
//using IntelliCareManagement.Domain.Interfaces;
using IntelliCareManagement.Infrastructure.Data;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(IntelliCareDbContext context) : base(context) { }

        public Task AddAsync(InvoiceDto invoice)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InvoiceDto invoice)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<InvoiceDto>> IInvoiceRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<InvoiceDto> IInvoiceRepository.GetByIdAsync(int invoiceId)
        {
            throw new NotImplementedException();
        }
        // Add custom methods for Invoice if needed
    }
}
