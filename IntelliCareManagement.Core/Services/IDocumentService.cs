using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{

    public interface IDocumentService
    {
        Task<IEnumerable<DocumentDto>> GetAllDocumentsAsync();
        Task<DocumentDto> GetDocumentByIdAsync(int documentId);
        Task AddDocumentAsync(DocumentDto document);
        Task UpdateDocumentAsync(DocumentDto document);
        Task DeleteDocumentAsync(int documentId);
    }

}
