using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{

    public interface IReportService
    {
        Task<IEnumerable<ReportDto>> GetAllReportsAsync();
        Task<ReportDto> GetReportByIdAsync(int reportId);
        Task AddReportAsync(ReportDto report);
        Task UpdateReportAsync(ReportDto report);
        Task DeleteReportAsync(int reportId);
    }

}
