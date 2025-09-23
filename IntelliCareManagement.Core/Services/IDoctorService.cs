using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{

    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto> GetDoctorByIdAsync(int doctorId);
        Task AddDoctorAsync(DoctorDto doctor);
        Task UpdateDoctorAsync(DoctorDto doctor);
        Task DeleteDoctorAsync(int doctorId);
    }

}
