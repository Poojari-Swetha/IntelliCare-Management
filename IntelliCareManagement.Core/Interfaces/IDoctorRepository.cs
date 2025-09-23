using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorDto>> GetAllAsync();
        Task<DoctorDto> GetByIdAsync(int doctorId);
        Task AddAsync(DoctorDto doctor);
        Task UpdateAsync(DoctorDto doctor);
        Task DeleteAsync(int doctorId);
    }

}
