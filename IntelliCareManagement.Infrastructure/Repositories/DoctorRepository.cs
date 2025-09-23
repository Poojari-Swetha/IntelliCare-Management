using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
//using IntelliCareManagement.Domain.Interfaces;
using IntelliCareManagement.Infrastructure.Data;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(IntelliCareDbContext context) : base(context) { }

        public Task AddAsync(DoctorDto doctor)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int doctorId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DoctorDto doctor)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<DoctorDto>> IDoctorRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<DoctorDto> IDoctorRepository.GetByIdAsync(int doctorId)
        {
            throw new NotImplementedException();
        }
        // Add custom methods for Doctor if needed
    }
}
