using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    // The ReportRepository class inherits from GenericRepository for common functionality
    // and implements the IReportRepository interface for specific report operations.
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        private readonly IntelliCareDbContext _context;

        public ReportRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        // Retrieves all reports from the database, maps them to DTOs, and returns them.
        public async Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            var reports = await _context.Reports.ToListAsync();
            return reports.Select(r => new ReportDto
            {
                ReportID = r.ReportID,
                Type = r.Type,
                GeneratedDate = r.GeneratedDate,
                Metrics = r.Metrics,
                PredictionDetails = r.PredictionDetails
            });
        }

        // Retrieves a single report by ID, maps it to a DTO, and returns it.
        public async Task<ReportDto> GetByIdAsync(int reportId)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(r => r.ReportID == reportId);
            if (report == null)
            {
                return null;
            }

            return new ReportDto
            {
                ReportID = report.ReportID,
                Type = report.Type,
                GeneratedDate = report.GeneratedDate,
                Metrics = report.Metrics,
                PredictionDetails = report.PredictionDetails
            };
        }

        // Adds a new report to the database from a DTO.
        public async Task AddAsync(ReportDto reportDto)
        {
            var report = new Report
            {
                Type = reportDto.Type,
                GeneratedDate = reportDto.GeneratedDate,
                Metrics = reportDto.Metrics,
                PredictionDetails = reportDto.PredictionDetails
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
        }

        // Updates an existing report in the database using a DTO.
        public async Task UpdateAsync(ReportDto reportDto)
        {
            var report = await _context.Reports.FindAsync(reportDto.ReportID);
            if (report != null)
            {
                report.Type = reportDto.Type;
                report.GeneratedDate = reportDto.GeneratedDate;
                report.Metrics = reportDto.Metrics;
                report.PredictionDetails = reportDto.PredictionDetails;

                _context.Reports.Update(report);
                await _context.SaveChangesAsync();
            }
        }

        // Deletes a report from the database by its ID.
        public async Task DeleteAsync(int reportId)
        {
            var report = await _context.Reports.FindAsync(reportId);
            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
            }
        }
    }
}
