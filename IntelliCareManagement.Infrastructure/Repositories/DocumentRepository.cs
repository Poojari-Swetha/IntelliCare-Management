using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
//using IntelliCareManagement.Domain.Interfaces;
using IntelliCareManagement.Infrastructure.Data;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(IntelliCareDbContext context) : base(context) { }

        public Task AddAsync(DocumentDto document)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int documentId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DocumentDto document)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<DocumentDto>> IDocumentRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<DocumentDto> IDocumentRepository.GetByIdAsync(int documentId)
        {
            throw new NotImplementedException();
        }
        // Add custom methods for Document if needed
    }
}
