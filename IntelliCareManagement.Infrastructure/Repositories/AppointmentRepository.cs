using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;
//using IntelliCareManagement.Core.Entities;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly IntelliCareDbContext _context;

        public AppointmentRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            return await _context.Appointments
                .Select(a => new AppointmentDto
                {
                    AppointmentID = a.AppointmentID,
                    PatientID = a.PatientID,
                    DoctorID = a.DoctorID,
                    Date_Time = a.Date_Time,
                    Status = a.Status,
                    QueuePosition = a.QueuePosition,
                    QueueStatus = a.QueueStatus
                })
                .ToListAsync();
        }

        public async Task<AppointmentDto> GetByIdAsync(int appointmentId)
        {
            var a = await _context.Appointments.FindAsync(appointmentId);
            if (a == null) return null;

            return new AppointmentDto
            {
                AppointmentID = a.AppointmentID,
                PatientID = a.PatientID,
                DoctorID = a.DoctorID,
                Date_Time = a.Date_Time,
                Status = a.Status,
                QueuePosition = a.QueuePosition,
                QueueStatus = a.QueueStatus
            };
        }

        public async Task AddAsync(AppointmentDto dto)
        {
            var entity = new Appointment
            {
                PatientID = dto.PatientID,
                DoctorID = dto.DoctorID,
                Date_Time = dto.Date_Time,
                Status = dto.Status,
                QueuePosition = dto.QueuePosition,
                QueueStatus = dto.QueueStatus
            };

            _context.Appointments.Add(entity);
            await _context.SaveChangesAsync();

            dto.AppointmentID = entity.AppointmentID;
        }

        public async Task UpdateAsync(AppointmentDto dto)
        {
            var entity = await _context.Appointments.FindAsync(dto.AppointmentID);
            if (entity == null) return;

            entity.PatientID = dto.PatientID;
            entity.DoctorID = dto.DoctorID;
            entity.Date_Time = dto.Date_Time;
            entity.Status = dto.Status;
            entity.QueuePosition = dto.QueuePosition;
            entity.QueueStatus = dto.QueueStatus;

            _context.Appointments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int appointmentId)
        {
            var entity = await _context.Appointments.FindAsync(appointmentId);
            if (entity == null) return;

            _context.Appointments.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
