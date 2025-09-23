using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        private readonly IntelliCareDbContext _context;

        public DocumentRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<DocumentDto> AddAsync(DocumentDto dto)
        {
            var entity = new Document
            {
                PatientID = dto.PatientID,
                DocumentType = dto.DocumentType,
                FilePath = dto.FilePath
            };

            await _context.Documents.AddAsync(entity);
            await _context.SaveChangesAsync();

            dto.DocumentID = entity.DocumentID;
            return dto;
        }

        public async Task DeleteAsync(int documentId)
        {
            var entity = await _context.Documents.FindAsync(documentId);
            if (entity != null)
            {
                _context.Documents.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(DocumentDto dto)
        {
            var entity = await _context.Documents.FindAsync(dto.DocumentID);
            if (entity != null)
            {
                entity.PatientID = dto.PatientID;
                entity.DocumentType = dto.DocumentType;
                entity.FilePath = dto.FilePath;

                _context.Documents.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DocumentDto>> GetAllAsync()
        {
            return await _context.Documents
                .Select(d => new DocumentDto
                {
                    DocumentID = d.DocumentID,
                    PatientID = d.PatientID,
                    DocumentType = d.DocumentType,
                    FilePath = d.FilePath
                })
                .ToListAsync();
        }

        public async Task<DocumentDto> GetByIdAsync(int documentId)
        {
            var entity = await _context.Documents.FindAsync(documentId);
            if (entity == null) return null;

            return new DocumentDto
            {
                DocumentID = entity.DocumentID,
                PatientID = entity.PatientID,
                DocumentType = entity.DocumentType,
                FilePath = entity.FilePath
            };
        }

        Task IDocumentRepository.AddAsync(DocumentDto document)
        {
            return AddAsync(document);
        }
    }
}
