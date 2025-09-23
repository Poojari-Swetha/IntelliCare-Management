using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
//using IntelliCareManagement.Domain.Interfaces;
using IntelliCareManagement.Infrastructure.Data;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class ConsultationRepository : GenericRepository<Consultation>, IConsultationRepository
    {
        public ConsultationRepository(IntelliCareDbContext context) : base(context) { }

        public Task AddAsync(ConsultationDto consultation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int consultationId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ConsultationDto consultation)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ConsultationDto>> IConsultationRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<ConsultationDto> IConsultationRepository.GetByIdAsync(int consultationId)
        {
            throw new NotImplementedException();
        }
        // Add custom methods for Consultation if needed
    }
}
