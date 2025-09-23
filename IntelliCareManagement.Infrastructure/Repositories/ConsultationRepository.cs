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
    public class ConsultationRepository : GenericRepository<Consultation>, IConsultationRepository
    {
        private readonly IntelliCareDbContext _context;

        public ConsultationRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConsultationDto>> GetAllAsync()
        {
            return await _context.Consultations
                .Select(c => new ConsultationDto
                {
                    ConsultationID = c.ConsultationID,
                    PatientID = c.PatientID,
                    DoctorID = c.DoctorID,
                    AppointmentID = c.AppointmentID,
                    Notes = c.Notes,
                    Diagnosis = c.Diagnosis
                })
                .ToListAsync();
        }

        public async Task<ConsultationDto> GetByIdAsync(int consultationId)
        {
            var c = await _context.Consultations.FindAsync(consultationId);
            if (c == null) return null;

            return new ConsultationDto
            {
                ConsultationID = c.ConsultationID,
                PatientID = c.PatientID,
                DoctorID = c.DoctorID,
                AppointmentID = c.AppointmentID,
                Notes = c.Notes,
                Diagnosis = c.Diagnosis
            };
        }

        public async Task AddAsync(ConsultationDto dto)
        {
            var entity = new Consultation
            {
                PatientID = dto.PatientID,
                DoctorID = dto.DoctorID,
                AppointmentID = dto.AppointmentID,
                Notes = dto.Notes,
                Diagnosis = dto.Diagnosis
            };

            _context.Consultations.Add(entity);
            await _context.SaveChangesAsync();

            dto.ConsultationID = entity.ConsultationID;
        }

        public async Task UpdateAsync(ConsultationDto dto)
        {
            var entity = await _context.Consultations.FindAsync(dto.ConsultationID);
            if (entity == null) return;

            entity.PatientID = dto.PatientID;
            entity.DoctorID = dto.DoctorID;
            entity.AppointmentID = dto.AppointmentID;
            entity.Notes = dto.Notes;
            entity.Diagnosis = dto.Diagnosis;

            _context.Consultations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int consultationId)
        {
            var entity = await _context.Consultations.FindAsync(consultationId);
            if (entity == null) return;

            _context.Consultations.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
