using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using IntelliCareManagement.Core.Interfaces; // Ensure this is correct

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class PatientProfileRepository : GenericRepository<PatientProfile>, IPatientProfileRepository
    {
        public PatientProfileRepository(IntelliCareDbContext context) : base(context) { }
    }
}
