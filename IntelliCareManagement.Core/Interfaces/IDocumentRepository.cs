using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IDocumentRepository
    {
        Task<IEnumerable<DocumentDto>> GetAllAsync();
        Task<DocumentDto> GetByIdAsync(int documentId);
        Task AddAsync(DocumentDto document);
        Task UpdateAsync(DocumentDto document);
        Task DeleteAsync(int documentId);
    }

}
