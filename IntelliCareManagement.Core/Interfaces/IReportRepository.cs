using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IReportRepository : IGenericRepository<Report>
    {
        Task<IEnumerable<ReportDto>> GetAllAsync();
        Task<ReportDto> GetByIdAsync(int reportId);
        Task AddAsync(ReportDto report);
        Task UpdateAsync(ReportDto report);
        Task DeleteAsync(int reportId);
    }

    public interface IGenericRepository<T>
    {
    }
}
