using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
//using IntelliCareManagement.Domain.Interfaces;
using IntelliCareManagement.Infrastructure.Data;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(IntelliCareDbContext context) : base(context) { }

        public Task AddAsync(AppointmentDto appointment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AppointmentDto appointment)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<AppointmentDto>> IAppointmentRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<AppointmentDto> IAppointmentRepository.GetByIdAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }
        // Add custom methods for Appointment if needed
    }
}
