using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
//using IntelliCareManagement.Domain.Interfaces;
using IntelliCareManagement.Infrastructure.Data;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        public ReportRepository(IntelliCareDbContext context) : base(context) { }

        public Task AddAsync(ReportDto report)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int reportId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ReportDto report)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ReportDto>> IReportRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<ReportDto> IReportRepository.GetByIdAsync(int reportId)
        {
            throw new NotImplementedException();
        }
        // Add custom methods for Report if needed
    }
}
