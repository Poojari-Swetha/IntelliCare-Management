using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{


    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> GetPatientByIdAsync(int patientId);
        Task AddPatientAsync(PatientDto patient);
        Task UpdatePatientAsync(PatientDto patient);
        Task DeletePatientAsync(int patientId);
    }

}
