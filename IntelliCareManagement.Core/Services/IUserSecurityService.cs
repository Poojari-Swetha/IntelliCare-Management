using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{


    public interface IUserSecurityService
    {
        Task<IEnumerable<UserSecurityDto>> GetAllUserSecuritiesAsync();
        Task<UserSecurityDto> GetUserSecurityByIdAsync(int securityId);
        Task AddUserSecurityAsync(UserSecurityDto security);
        Task UpdateUserSecurityAsync(UserSecurityDto security);
        Task DeleteUserSecurityAsync(int securityId);
    }

}
