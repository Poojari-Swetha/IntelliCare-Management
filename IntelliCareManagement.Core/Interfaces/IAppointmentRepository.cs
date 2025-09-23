using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IAppointmentRepository
    {
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto> GetByIdAsync(int appointmentId);
        Task AddAsync(AppointmentDto appointment);
        Task UpdateAsync(AppointmentDto appointment);
        Task DeleteAsync(int appointmentId);
    }

}
