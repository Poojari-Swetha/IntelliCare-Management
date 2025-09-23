using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
//using IntelliCareManagement.Domain.Interfaces;
using IntelliCareManagement.Infrastructure.Data;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class UserSecurityRepository : GenericRepository<UserSecurity>, IUserSecurityRepository
    {
        public UserSecurityRepository(IntelliCareDbContext context) : base(context) { }

        public Task AddAsync(UserSecurityDto security)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int securityId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserSecurityDto security)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<UserSecurityDto>> IUserSecurityRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<UserSecurityDto> IUserSecurityRepository.GetByIdAsync(int securityId)
        {
            throw new NotImplementedException();
        }
        // Add custom methods for UserSecurity if needed
    }
}
