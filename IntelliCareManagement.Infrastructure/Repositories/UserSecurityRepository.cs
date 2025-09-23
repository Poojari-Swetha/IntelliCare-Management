using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntelliCareManagement.Core.DTOs;
//using IntelliCareManagement.Core.Entities;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class UserSecurityRepository : GenericRepository<UserSecurity>, IUserSecurityRepository
    {
        private readonly IntelliCareDbContext _context;

        public UserSecurityRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserSecurityDto>> GetAllAsync()
        {
            return await _context.UserSecurities
                .Select(s => new UserSecurityDto
                {
                    SecurityID = s.SecurityID,
                    UserID = s.UserID,
                    OTPCode = s.OTPCode,
                    OTPExpiry = s.OTPExpiry,
                    IsOTPVerified = s.IsOTPVerified,
                    APIToken = s.APIToken,
                    TokenExpiry = s.TokenExpiry,
                    IsTokenActive = s.IsTokenActive
                })
                .ToListAsync();
        }

        public async Task<UserSecurityDto> GetByIdAsync(int securityId)
        {
            var s = await _context.UserSecurities.FindAsync(securityId);
            if (s == null) return null;

            return new UserSecurityDto
            {
                SecurityID = s.SecurityID,
                UserID = s.UserID,
                OTPCode = s.OTPCode,
                OTPExpiry = s.OTPExpiry,
                IsOTPVerified = s.IsOTPVerified,
                APIToken = s.APIToken,
                TokenExpiry = s.TokenExpiry,
                IsTokenActive = s.IsTokenActive
            };
        }

        public async Task AddAsync(UserSecurityDto dto)
        {
            var entity = new UserSecurity
            {
                UserID = dto.UserID,
                OTPCode = dto.OTPCode,
                OTPExpiry = dto.OTPExpiry,
                IsOTPVerified = dto.IsOTPVerified,
                APIToken = dto.APIToken,
                TokenExpiry = dto.TokenExpiry,
                IsTokenActive = dto.IsTokenActive
            };

            _context.UserSecurities.Add(entity);
            await _context.SaveChangesAsync();

            dto.SecurityID = entity.SecurityID;
        }

        public async Task UpdateAsync(UserSecurityDto dto)
        {
            var entity = await _context.UserSecurities.FindAsync(dto.SecurityID);
            if (entity == null) return;

            entity.UserID = dto.UserID;
            entity.OTPCode = dto.OTPCode;
            entity.OTPExpiry = dto.OTPExpiry;
            entity.IsOTPVerified = dto.IsOTPVerified;
            entity.APIToken = dto.APIToken;
            entity.TokenExpiry = dto.TokenExpiry;
            entity.IsTokenActive = dto.IsTokenActive;

            _context.UserSecurities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int securityId)
        {
            var entity = await _context.UserSecurities.FindAsync(securityId);
            if (entity == null) return;

            _context.UserSecurities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
