using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{


    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<AppointmentDto> GetAppointmentByIdAsync(int appointmentId);
        Task AddAppointmentAsync(AppointmentDto appointment);
        Task UpdateAppointmentAsync(AppointmentDto appointment);
        Task DeleteAppointmentAsync(int appointmentId);
    }

}
