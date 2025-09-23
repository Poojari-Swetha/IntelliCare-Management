using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IPatientRepository
    {
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(int patientId);
        Task AddAsync(PatientDto patient);
        Task UpdateAsync(PatientDto patient);
        Task DeleteAsync(int patientId);
    }

}
