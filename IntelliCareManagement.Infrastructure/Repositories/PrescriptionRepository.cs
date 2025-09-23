using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
    {
        private readonly IntelliCareDbContext _context;

        public PrescriptionRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PrescriptionDto> AddAsync(PrescriptionDto dto)
        {
            var entity = new Prescription
            {
                ConsultationID = dto.ConsultationID,
                Medication = dto.Medication,
                Dosage = dto.Dosage,
                Duration = dto.Duration,
                PharmacyName = dto.PharmacyName,
                PharmacyStatus = dto.PharmacyStatus,
                DeliveryETA = dto.DeliveryETA
            };

            await _context.Prescriptions.AddAsync(entity);
            await _context.SaveChangesAsync();

            dto.PrescriptionID = entity.PrescriptionID;
            return dto;
        }

        public async Task DeleteAsync(int prescriptionId)
        {
            var entity = await _context.Prescriptions.FindAsync(prescriptionId);
            if (entity != null)
            {
                _context.Prescriptions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(PrescriptionDto dto)
        {
            var entity = await _context.Prescriptions.FindAsync(dto.PrescriptionID);
            if (entity != null)
            {
                entity.ConsultationID = dto.ConsultationID;
                entity.Medication = dto.Medication;
                entity.Dosage = dto.Dosage;
                entity.Duration = dto.Duration;
                entity.PharmacyName = dto.PharmacyName;
                entity.PharmacyStatus = dto.PharmacyStatus;
                entity.DeliveryETA = dto.DeliveryETA;

                _context.Prescriptions.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PrescriptionDto>> GetAllAsync()
        {
            return await _context.Prescriptions
                .Select(p => new PrescriptionDto
                {
                    PrescriptionID = p.PrescriptionID,
                    ConsultationID = p.ConsultationID,
                    Medication = p.Medication,
                    Dosage = p.Dosage,
                    Duration = p.Duration,
                    PharmacyName = p.PharmacyName,
                    PharmacyStatus = p.PharmacyStatus,
                    DeliveryETA = p.DeliveryETA
                })
                .ToListAsync();
        }

        public async Task<PrescriptionDto> GetByIdAsync(int prescriptionId)
        {
            var entity = await _context.Prescriptions.FindAsync(prescriptionId);
            if (entity == null) return null;

            return new PrescriptionDto
            {
                PrescriptionID = entity.PrescriptionID,
                ConsultationID = entity.ConsultationID,
                Medication = entity.Medication,
                Dosage = entity.Dosage,
                Duration = entity.Duration,
                PharmacyName = entity.PharmacyName,
                PharmacyStatus = entity.PharmacyStatus,
                DeliveryETA = entity.DeliveryETA
            };
        }

        Task IPrescriptionRepository.AddAsync(PrescriptionDto prescription)
        {
            return AddAsync(prescription);
        }
    }
}
