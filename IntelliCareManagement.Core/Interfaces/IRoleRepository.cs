using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Interfaces
{


    public interface IRoleRepository
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto> GetByIdAsync(int roleId);
        Task AddAsync(RoleDto role);
        Task UpdateAsync(RoleDto role);
        Task DeleteAsync(int roleId);
    }

}
