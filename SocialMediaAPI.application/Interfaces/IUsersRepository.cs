﻿using SocialMediaAPI.domain.entities;

namespace SocialMediaAPI.application.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> GetUserByIdAsync(int userId);
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> AddUserAsync(Users user);
        Task<Users> UpdateUserAsync(Users user);
        Task<bool> DeleteUserAsync(int userId);

        // New Method
        Task<Users?> GetUserByUsernameAsync(string username);
    }
}
