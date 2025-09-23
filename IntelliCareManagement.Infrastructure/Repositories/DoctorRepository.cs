using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    // The DoctorRepository implements the IDoctorRepository interface
    // to provide concrete data access logic for Doctor entities.
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly IntelliCareDbContext _context;

        // The constructor receives the database context via dependency injection.
        public DoctorRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        // Retrieves all doctors from the database and maps them to DTOs.
        public async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var doctors = await _context.Set<Doctor>().ToListAsync();
            // Map the Doctor entities to DoctorDto objects.
            return doctors.Select(d => new DoctorDto
            {
                DoctorID = d.DoctorID,
                Name = d.Name,
                Specialty = d.Specialty,
                ContactInfo = d.ContactInfo
            }).ToList();
        }

        // Retrieves a single doctor by their ID and maps it to a DTO.
        public async Task<DoctorDto> GetByIdAsync(int doctorId)
        {
            var doctor = await _context.Set<Doctor>().FindAsync(doctorId);
            // If the doctor is not found, return null.
            if (doctor == null) return null;

            // Map the Doctor entity to a DoctorDto object.
            return new DoctorDto
            {
                DoctorID = doctor.DoctorID,
                Name = doctor.Name,
                Specialty = doctor.Specialty,
                ContactInfo = doctor.ContactInfo
            };
        }

        // Adds a new doctor to the database.
        public async Task AddAsync(DoctorDto doctorDto)
        {
            // Map the DTO to a Doctor entity.
            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Specialty = doctorDto.Specialty,
                ContactInfo = doctorDto.ContactInfo
            };

            // Add the new doctor entity to the database context.
            await _context.Set<Doctor>().AddAsync(doctor);
            // Save the changes to the database.
            await _context.SaveChangesAsync();
        }

        // Updates an existing doctor in the database.
        public async Task UpdateAsync(DoctorDto doctorDto)
        {
            // Find the existing doctor entity in the database.
            var existingDoctor = await _context.Set<Doctor>().FindAsync(doctorDto.DoctorID);

            if (existingDoctor != null)
            {
                // Update the properties of the existing entity.
                existingDoctor.Name = doctorDto.Name;
                existingDoctor.Specialty = doctorDto.Specialty;
                existingDoctor.ContactInfo = doctorDto.ContactInfo;

                // Mark the entity as modified and save changes.
                _context.Entry(existingDoctor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        // Deletes a doctor from the database by ID.
        public async Task DeleteAsync(int doctorId)
        {
            // Find the doctor entity to be deleted.
            var doctor = await _context.Set<Doctor>().FindAsync(doctorId);
            if (doctor != null)
            {
                // Remove the entity from the database context.
                _context.Set<Doctor>().Remove(doctor);
                // Save the changes to the database.
                await _context.SaveChangesAsync();
            }
        }
    }
}
