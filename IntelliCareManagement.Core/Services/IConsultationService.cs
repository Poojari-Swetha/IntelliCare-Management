using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{

    public interface IConsultationService
    {
        Task<IEnumerable<ConsultationDto>> GetAllConsultationsAsync();
        Task<ConsultationDto> GetConsultationByIdAsync(int consultationId);
        Task AddConsultationAsync(ConsultationDto consultation);
        Task UpdateConsultationAsync(ConsultationDto consultation);
        Task DeleteConsultationAsync(int consultationId);
    }

}
