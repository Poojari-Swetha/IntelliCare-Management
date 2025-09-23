using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class PatientProfileRepository : GenericRepository<PatientProfile>, IPatientProfileRepository
    {
        private readonly IntelliCareDbContext _context;

        public PatientProfileRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PatientDto> AddAsync(PatientDto dto)
        {
            var entity = new PatientProfile
            {
                Name = dto.Name,
                DOB = dto.DOB,
                ContactInfo = dto.ContactInfo,
                InsuranceDetails = dto.InsuranceDetails,
                MedicalHistory = dto.MedicalHistory
            };

            await _context.PatientProfiles.AddAsync(entity);
            await _context.SaveChangesAsync();

            dto.PatientID = entity.PatientID;
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.PatientProfiles.FindAsync(id);
            if (entity != null)
            {
                _context.PatientProfiles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(PatientDto dto)
        {
            var entity = await _context.PatientProfiles.FindAsync(dto.PatientID);
            if (entity != null)
            {
                entity.Name = dto.Name;
                entity.DOB = dto.DOB;
                entity.ContactInfo = dto.ContactInfo;
                entity.InsuranceDetails = dto.InsuranceDetails;
                entity.MedicalHistory = dto.MedicalHistory;

                _context.PatientProfiles.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            return await _context.PatientProfiles
                .Select(p => new PatientDto
                {
                    PatientID = p.PatientID,
                    Name = p.Name,
                    DOB = p.DOB,
                    ContactInfo = p.ContactInfo,
                    InsuranceDetails = p.InsuranceDetails,
                    MedicalHistory = p.MedicalHistory
                })
                .ToListAsync();
        }

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var entity = await _context.PatientProfiles.FindAsync(id);
            if (entity == null) return null;

            return new PatientDto
            {
                PatientID = entity.PatientID,
                Name = entity.Name,
                DOB = entity.DOB,
                ContactInfo = entity.ContactInfo,
                InsuranceDetails = entity.InsuranceDetails,
                MedicalHistory = entity.MedicalHistory
            };
        }
    }
}
