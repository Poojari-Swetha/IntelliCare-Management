using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IReportRepository
    {
        Task<IEnumerable<ReportDto>> GetAllAsync();
        Task<ReportDto> GetByIdAsync(int reportId);
        Task AddAsync(ReportDto report);
        Task UpdateAsync(ReportDto report);
        Task DeleteAsync(int reportId);
    }

}
