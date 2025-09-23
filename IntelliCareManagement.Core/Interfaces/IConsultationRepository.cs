using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IConsultationRepository
    {
        Task<IEnumerable<ConsultationDto>> GetAllAsync();
        Task<ConsultationDto> GetByIdAsync(int consultationId);
        Task AddAsync(ConsultationDto consultation);
        Task UpdateAsync(ConsultationDto consultation);
        Task DeleteAsync(int consultationId);
    }

}
