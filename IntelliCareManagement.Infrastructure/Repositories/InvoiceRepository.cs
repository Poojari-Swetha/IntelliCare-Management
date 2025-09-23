using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        private readonly IntelliCareDbContext _context;

        public InvoiceRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(InvoiceDto invoice)
        {
            var newInvoice = new Invoice
            {
                InvoiceID = invoice.InvoiceID,
                PatientID = invoice.PatientID,
                Amount = invoice.Amount,
                InsuranceProvider = invoice.InsuranceProvider,
                Status = invoice.Status,
                ClaimStatus = invoice.ClaimStatus,
                SubmissionDate = invoice.SubmissionDate,
                ApprovalDate = invoice.ApprovalDate
            };

            await _context.Invoices.AddAsync(newInvoice);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
        {
            var invoices = await _context.Invoices.ToListAsync();

            // Map the entities back to DTOs
            return invoices.Select(i => new InvoiceDto
            {
                InvoiceID = i.InvoiceID,
                PatientID = i.PatientID,
                Amount = i.Amount,
                InsuranceProvider = i.InsuranceProvider,
                Status = i.Status,
                ClaimStatus = i.ClaimStatus,
                SubmissionDate = i.SubmissionDate,
                ApprovalDate = i.ApprovalDate
            }).ToList();
        }

        public async Task<InvoiceDto> GetByIdAsync(int invoiceId)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);

            if (invoice == null)
            {
                return null;
            }

            return new InvoiceDto
            {
                InvoiceID = invoice.InvoiceID,
                PatientID = invoice.PatientID,
                Amount = invoice.Amount,
                InsuranceProvider = invoice.InsuranceProvider,
                Status = invoice.Status,
                ClaimStatus = invoice.ClaimStatus,
                SubmissionDate = invoice.SubmissionDate,
                ApprovalDate = invoice.ApprovalDate
            };
        }

        public Task DeleteAsync(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InvoiceDto invoice)
        {
            throw new NotImplementedException();
        }
    }
}