using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IPrescriptionRepository
    {
        Task<IEnumerable<PrescriptionDto>> GetAllAsync();
        Task<PrescriptionDto> GetByIdAsync(int prescriptionId);
        Task AddAsync(PrescriptionDto prescription);
        Task UpdateAsync(PrescriptionDto prescription);
        Task DeleteAsync(int prescriptionId);
    }

}
