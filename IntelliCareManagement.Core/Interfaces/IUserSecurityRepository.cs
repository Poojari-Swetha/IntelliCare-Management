using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IUserSecurityRepository
    {
        Task<IEnumerable<UserSecurityDto>> GetAllAsync();
        Task<UserSecurityDto> GetByIdAsync(int securityId);
        Task AddAsync(UserSecurityDto security);
        Task UpdateAsync(UserSecurityDto security);
        Task DeleteAsync(int securityId);
    }

}
