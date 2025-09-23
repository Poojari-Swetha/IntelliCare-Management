using IntelliCareManagement.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.Interfaces
{
    public interface IPatientProfileRepository
    {
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(int id);
        Task<PatientDto> AddAsync(PatientDto dto); // <-- updated
        Task UpdateAsync(PatientDto dto);
        Task DeleteAsync(int id);
    }

}
