using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;

namespace IntelliCareManagement.Core.Services
{


    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(int roleId);
        Task AddRoleAsync(RoleDto role);
        Task UpdateRoleAsync(RoleDto role);
        Task DeleteRoleAsync(int roleId);
    }

}
