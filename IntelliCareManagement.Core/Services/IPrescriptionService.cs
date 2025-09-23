using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{


    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync();
        Task<PrescriptionDto> GetPrescriptionByIdAsync(int prescriptionId);
        Task AddPrescriptionAsync(PrescriptionDto prescription);
        Task UpdatePrescriptionAsync(PrescriptionDto prescription);
        Task DeletePrescriptionAsync(int prescriptionId);
    }

}
