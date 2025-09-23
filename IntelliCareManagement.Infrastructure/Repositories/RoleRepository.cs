using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IntelliCareDbContext _context;

        public RoleRepository(IntelliCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles.Select(r => new RoleDto
            {
                RoleID = r.RoleID,
                RoleName = r.RoleName
            });
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return null;

            return new RoleDto
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName
            };
        }

        public async Task AddAsync(RoleDto dto)
        {
            var role = new Role
            {
                RoleName = dto.RoleName
            };

            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            dto.RoleID = role.RoleID;
        }

        public async Task UpdateAsync(RoleDto dto)
        {
            var role = await _context.Roles.FindAsync(dto.RoleID);
            if (role == null) return;

            role.RoleName = dto.RoleName;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}
