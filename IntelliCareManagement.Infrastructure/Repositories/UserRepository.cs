using IntelliCareManagement.Core.DTOs;
using IntelliCareManagement.Core.Interfaces;
using IntelliCareManagement.Domain.Entities;
using IntelliCareManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IntelliCareManagement.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IntelliCareDbContext _context;

        public UserRepository(IntelliCareDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = userDto.PasswordHash,
                RoleID = userDto.RoleID,
                PatientID = userDto.PatientID,
                DoctorID = userDto.DoctorID,
                Email = userDto.Email
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            userDto.UserID = user.UserID;
            return userDto;
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto> UpdateAsync(UserDto userDto)
        {
            var user = await _context.Users.FindAsync(userDto.UserID);
            if (user == null) return null;

            user.Username = userDto.Username;
            user.PasswordHash = userDto.PasswordHash;
            user.RoleID = userDto.RoleID;
            user.PatientID = userDto.PatientID;
            user.DoctorID = userDto.DoctorID;
            user.Email = userDto.Email;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    UserID = u.UserID,
                    Username = u.Username,
                    PasswordHash = u.PasswordHash,
                    RoleID = u.RoleID,
                    PatientID = u.PatientID,
                    DoctorID = u.DoctorID,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            return new UserDto
            {
                UserID = user.UserID,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                RoleID = user.RoleID,
                PatientID = user.PatientID,
                DoctorID = user.DoctorID,
                Email = user.Email
            };
        }

        Task IUserRepository.AddAsync(UserDto user)
        {
            return AddAsync(user);
        }

        Task IUserRepository.UpdateAsync(UserDto user)
        {
            return UpdateAsync(user);
        }

        Task IUserRepository.DeleteAsync(int userId)
        {
            return DeleteAsync(userId);
        }
    }
}
