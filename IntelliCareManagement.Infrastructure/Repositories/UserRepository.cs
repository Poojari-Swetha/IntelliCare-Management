using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
//using IntelliCareManagement.Domain.Interfaces;
using IntelliCareManagement.Infrastructure.Data;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IntelliCareDbContext context) : base(context) { }

        public Task AddAsync(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDto user)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<UserDto>> IUserRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<UserDto> IUserRepository.GetByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
        // Add custom methods for User if needed
    }
}
