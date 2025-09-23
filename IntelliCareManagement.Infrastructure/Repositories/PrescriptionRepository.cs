using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
//using IntelliCareManagement.Domain.Interfaces;
using IntelliCareManagement.Infrastructure.Data;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(IntelliCareDbContext context) : base(context) { }

        public Task AddAsync(PrescriptionDto prescription)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int prescriptionId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PrescriptionDto prescription)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<PrescriptionDto>> IPrescriptionRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<PrescriptionDto> IPrescriptionRepository.GetByIdAsync(int prescriptionId)
        {
            throw new NotImplementedException();
        }
        // Add custom methods for Prescription if needed
    }
}
